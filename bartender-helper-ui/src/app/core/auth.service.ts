import { computed, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { AuthResponse } from './models';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly TOKEN_KEY = 'bartender_token';
  private readonly USERNAME_KEY = 'bartender_username';

  private _username = signal<string | null>(localStorage.getItem(this.USERNAME_KEY));

  readonly username = this._username.asReadonly();
  readonly isLoggedIn = computed(() => this._username() !== null);

  constructor(private http: HttpClient, private router: Router) {}

  register(username: string, password: string) {
    return this.http.post<AuthResponse>('/api/auth/register', { username, password })
      .pipe(tap(res => this.handleAuth(res)));
  }

  login(username: string, password: string) {
    return this.http.post<AuthResponse>('/api/auth/login', { username, password })
      .pipe(tap(res => this.handleAuth(res)));
  }

  logout() {
    localStorage.removeItem(this.TOKEN_KEY);
    localStorage.removeItem(this.USERNAME_KEY);
    this._username.set(null);
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  private handleAuth(res: AuthResponse) {
    localStorage.setItem(this.TOKEN_KEY, res.token);
    localStorage.setItem(this.USERNAME_KEY, res.username);
    this._username.set(res.username);
  }
}
