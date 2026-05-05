import { Component, input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { CocktailSummary } from '../core/models';

@Component({
  selector: 'app-cocktail-card',
  imports: [RouterLink, MatCardModule, MatChipsModule],
  templateUrl: './cocktail-card.html',
  styleUrl: './cocktail-card.scss'
})
export class CocktailCard {
  cocktail = input.required<CocktailSummary>();
}
