import { Component, input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { CocktailSummary } from '../core/models';
import { CocktailDialog } from './cocktail-dialog';

@Component({
  selector: 'app-cocktail-card',
  imports: [MatCardModule, MatIconModule],
  templateUrl: './cocktail-card.html',
  styleUrl: './cocktail-card.scss'
})
export class CocktailCard {
  cocktail = input.required<CocktailSummary>();

  constructor(private dialog: MatDialog) {}

  openDialog() {
    this.dialog.open(CocktailDialog, {
      data: { id: this.cocktail().id },
      width: '520px',
      maxHeight: '90vh'
    });
  }
}
