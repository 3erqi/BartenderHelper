import { Component, OnInit, inject, signal } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CocktailService } from '../core/cocktail';
import { AuthService } from '../core/auth.service';
import { CocktailDetail } from '../core/models';

@Component({
  selector: 'app-cocktail-dialog',
  imports: [MatDialogModule, MatButtonModule, MatIconModule],
  templateUrl: './cocktail-dialog.html',
  styleUrl: './cocktail-dialog.scss'
})
export class CocktailDialog implements OnInit {
  private data = inject<{ id: number }>(MAT_DIALOG_DATA);
  private dialogRef = inject(MatDialogRef<CocktailDialog>);
  private cocktailService = inject(CocktailService);
  private router = inject(Router);
  protected authService = inject(AuthService);

  cocktail = signal<CocktailDetail | null>(null);

  ngOnInit() {
    this.cocktailService.getById(this.data.id).subscribe((c) => this.cocktail.set(c));
  }

  get isOwner(): boolean {
    return this.cocktail()?.ownerUsername === this.authService.username();
  }

  edit() {
    this.dialogRef.close();
    this.router.navigate(['/edit', this.cocktail()!.id]);
  }

  delete() {
    const id = this.cocktail()?.id;
    if (!id) return;
    this.cocktailService.delete(id).subscribe(() => this.dialogRef.close('deleted'));
  }
}
