import { computed, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { AuthResponse } from './models';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly TOKEN_KEY = 'bartender_token';
  private readonly USERNAME_KEY = 'bartender_username';
  private readonly AVATAR_KEY_PREFIX = 'bartender_avatar_';

  private _username = signal<string | null>(localStorage.getItem(this.USERNAME_KEY));
  private _avatarIndex = signal<number | null>(
    this._username() ? this.getOrAssignAvatar(this._username()!) : null
  );

  readonly username = this._username.asReadonly();
  readonly isLoggedIn = computed(() => this._username() !== null);
  readonly avatarUrl = computed(() => {
    const idx = this._avatarIndex();
    if (idx === null) return null;
    const ext = idx === 1 ? 'png' : 'gif';
    const num = String(idx).padStart(2, '0');
    return `avatars/80381876-d5f7-4a25-acff-ac0abf6196e0_${num}.${ext}`;
  });

  constructor(private http: HttpClient, private router: Router) {}

  register(username: string, email: string, password: string) {
    return this.http.post<AuthResponse>('/api/auth/register', { username, email, password })
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
    this._avatarIndex.set(null);
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  private getOrAssignAvatar(username: string): number {
    const key = `${this.AVATAR_KEY_PREFIX}${username}`;
    const stored = localStorage.getItem(key);
    if (stored) return parseInt(stored, 10);
    const random = Math.floor(Math.random() * 36) + 1;
    localStorage.setItem(key, String(random));
    return random;
  }

  private handleAuth(res: AuthResponse) {
    localStorage.setItem(this.TOKEN_KEY, res.token);
    localStorage.setItem(this.USERNAME_KEY, res.username);
    this._username.set(res.username);
    this._avatarIndex.set(this.getOrAssignAvatar(res.username));
  }
}
