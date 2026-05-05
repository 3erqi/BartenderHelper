import { Routes } from '@angular/router';
import { authGuard } from './core/auth.guard';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', loadComponent: () => import('./features/home').then(m => m.Home) },
  { path: 'cocktail/:id', loadComponent: () => import('./features/cocktail-detail').then(m => m.CocktailDetail) },
  { path: 'add', loadComponent: () => import('./features/cocktail-form').then(m => m.CocktailForm), canActivate: [authGuard] },
  { path: 'edit/:id', loadComponent: () => import('./features/cocktail-form').then(m => m.CocktailForm), canActivate: [authGuard] },
  { path: 'login', loadComponent: () => import('./features/auth/login').then(m => m.Login) },
  { path: 'register', loadComponent: () => import('./features/auth/register').then(m => m.Register) },
  { path: '**', redirectTo: 'home' }
];
