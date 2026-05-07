import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CocktailService } from '../core/cocktail';
import { AuthService } from '../core/auth.service';
import { CocktailDetail as CocktailDetailModel } from '../core/models';

@Component({
  selector: 'app-cocktail-detail',
  imports: [RouterLink, MatButtonModule, MatIconModule],
  templateUrl: './cocktail-detail.html',
  styleUrl: './cocktail-detail.scss'
})
export class CocktailDetail implements OnInit {
  cocktail = signal<CocktailDetailModel | null>(null);

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private cocktailService: CocktailService,
    protected authService: AuthService
  ) {}

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.cocktailService.getById(id).subscribe(c => this.cocktail.set(c));
  }

  get isOwner(): boolean {
    return this.cocktail()?.ownerUsername === this.authService.username();
  }

  delete() {
    const id = this.cocktail()?.id;
    if (!id) return;
    this.cocktailService.delete(id).subscribe(() => this.router.navigate(['/home']));
  }
}
