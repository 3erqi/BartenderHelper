import { Component, OnDestroy, OnInit, signal } from '@angular/core';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { RouterLink } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CocktailCard } from '../shared/cocktail-card';
import { CocktailService } from '../core/cocktail';
import { AuthService } from '../core/auth.service';
import { CocktailSummary } from '../core/models';

@Component({
  selector: 'app-profile',
  imports: [
    RouterLink,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    CocktailCard
  ],
  templateUrl: './profile.html',
  styleUrl: './profile.scss'
})
export class Profile implements OnInit, OnDestroy {
  cocktails = signal<CocktailSummary[]>([]);
  loading = signal(false);

  private search$ = new Subject<string>();
  private sub!: Subscription;

  constructor(
    private cocktailService: CocktailService,
    protected authService: AuthService // <-- protected so the HTML template can use it
  ) {}

  ngOnInit() {
    this.sub = this.search$
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        switchMap((term) => {
          this.loading.set(true);
          return this.cocktailService.getMyCocktails(term); // <-- only difference from Home
        })
      )
      .subscribe((results) => {
        this.cocktails.set(results);
        this.loading.set(false);
      });

    this.search$.next(''); // trigger an initial load with empty search
  }

  onSearch(event: Event) {
    this.search$.next((event.target as HTMLInputElement).value);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
