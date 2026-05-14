import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Location } from '@angular/common';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CocktailService } from '../core/cocktail';

@Component({
  selector: 'app-cocktail-form',
  imports: [
    RouterLink,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './cocktail-form.html',
  styleUrl: './cocktail-form.scss'
})
export class CocktailForm implements OnInit {
  form!: FormGroup;
  editId: number | null = null;
  saving = signal(false);
  error = signal('');
  uploading = signal(false);
  imagePreview = signal<string | null>(null);

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private location: Location,
    private cocktailService: CocktailService
  ) {}

  ngOnInit() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      glassType: ['', Validators.required],
      imageUrl: [''],
      instructionSteps: this.fb.array([this.newInstruction()]),
      ingredients: this.fb.array([this.newIngredient()])
    });

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.editId = Number(id);
      this.cocktailService.getById(this.editId).subscribe((c) => {
        if (c.imageUrl) this.imagePreview.set(c.imageUrl);

        this.form.patchValue({
          name: c.name,
          description: c.description,
          glassType: c.glassType,
          imageUrl: c.imageUrl ?? ''
        });

        this.form.setControl(
          'instructionSteps',
          this.fb.array(
            (c.instructions || '')
              .split('\n')
              .filter((s) => s.trim())
              .map((step) => this.fb.group({ step: [step.trim(), Validators.required] }))
          )
        );

        this.form.setControl(
          'ingredients',
          this.fb.array(
            c.ingredients.map((i) =>
              this.fb.group({
                name: [i.name, Validators.required],
                amount: [i.amount, Validators.required],
                unit: [i.unit]
              })
            )
          )
        );
      });
    }
  }

  get ingredients(): FormArray {
    return this.form.get('ingredients') as FormArray;
  }

  get instructionSteps(): FormArray {
    return this.form.get('instructionSteps') as FormArray;
  }

  newInstruction(): FormGroup {
    return this.fb.group({ step: ['', Validators.required] });
  }

  addInstruction() {
    this.instructionSteps.push(this.newInstruction());
  }

  removeInstruction(index: number) {
    if (this.instructionSteps.length > 1) this.instructionSteps.removeAt(index);
  }

  newIngredient(): FormGroup {
    return this.fb.group({
      name: ['', Validators.required],
      amount: ['', Validators.required],
      unit: ['']
    });
  }

  addIngredient() {
    this.ingredients.push(this.newIngredient());
  }

  removeIngredient(index: number) {
    if (this.ingredients.length > 1) this.ingredients.removeAt(index);
  }

  submit() {
    if (this.form.invalid) return;
    this.saving.set(true);
    this.error.set('');

    const request = {
      name: this.form.value.name,
      description: this.form.value.description,
      glassType: this.form.value.glassType,
      imageUrl: this.form.value.imageUrl || null,
      instructions: this.form.value.instructionSteps.map((i: any) => i.step).join('\n'),
      ingredients: this.form.value.ingredients.map((i: any) => ({
        ...i,
        unit: i.unit || null
      }))
    };

    const call = this.editId
      ? this.cocktailService.update(this.editId, request)
      : this.cocktailService.create(request);

    call.subscribe({
      next: () => {
        this.location.back();
      },
      error: (err) => {
        const msg =
          typeof err.error === 'string' ? err.error : (err.error?.title ?? 'Something went wrong.');
        this.error.set(msg);
        this.saving.set(false);
      }
    });
  }

  onImageSelected(event: Event) {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (!file) return;
    this.uploading.set(true);
    this.cocktailService.uploadImage(file).subscribe({
      next: (res) => {
        this.form.patchValue({ imageUrl: res.url });
        this.imagePreview.set(res.url);
        this.uploading.set(false);
      },
      error: () => {
        this.error.set('Image upload failed.');
        this.uploading.set(false);
      }
    });
  }
}
