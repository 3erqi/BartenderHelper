import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CocktailService } from '../core/cocktail';

@Component({
  selector: 'app-cocktail-form',
  imports: [
    RouterLink, ReactiveFormsModule,
    MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule
  ],
  templateUrl: './cocktail-form.html',
  styleUrl: './cocktail-form.scss'
})
export class CocktailForm implements OnInit {
  form!: FormGroup;
  editId: number | null = null;
  saving = signal(false);
  error = signal('');

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private cocktailService: CocktailService
  ) {}

  ngOnInit() {
    this.form = this.fb.group({
      name:         ['', Validators.required],
      description:  ['', Validators.required],
      instructions: ['', Validators.required],
      glassType:    ['', Validators.required],
      imageUrl:     [''],
      ingredients:  this.fb.array([this.newIngredient()])
    });

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.editId = Number(id);
      this.cocktailService.getById(this.editId).subscribe(c => {
        this.form.patchValue({
          name: c.name,
          description: c.description,
          instructions: c.instructions,
          glassType: c.glassType,
          imageUrl: c.imageUrl ?? ''
        });
        this.form.setControl('ingredients', this.fb.array(
          c.ingredients.map(i => this.fb.group({
            name:   [i.name,   Validators.required],
            amount: [i.amount, Validators.required],
            unit:   [i.unit]
          }))
        ));
      });
    }
  }

  get ingredients(): FormArray {
    return this.form.get('ingredients') as FormArray;
  }

  newIngredient(): FormGroup {
    return this.fb.group({
      name:   ['', Validators.required],
      amount: ['', Validators.required],
      unit:   ['']
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
      ...this.form.value,
      imageUrl: this.form.value.imageUrl || null,
      ingredients: this.form.value.ingredients.map((i: any) => ({
        ...i,
        unit: i.unit || null
      }))
    };

    const call = this.editId
      ? this.cocktailService.update(this.editId, request)
      : this.cocktailService.create(request);

    call.subscribe({
      next: (res) => {
        const id = this.editId ?? (res as number);
        this.router.navigate(['/cocktail', id]);
      },
      error: err => {
        const msg = typeof err.error === 'string'
          ? err.error
          : err.error?.title ?? 'Something went wrong.';
        this.error.set(msg);
        this.saving.set(false);
      }
    });
  }
}
