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
  private _avatarUrl = signal<string | null>(
    this._username() ? this.getOrAssignAvatar(this._username()!) : null
  );

  readonly username = this._username.asReadonly();
  readonly isLoggedIn = computed(() => this._username() !== null);
  readonly avatarUrl = this._avatarUrl.asReadonly();

  constructor(
    private http: HttpClient,
    private router: Router
  ) {}

  register(username: string, email: string, password: string) {
    return this.http
      .post<AuthResponse>('/api/auth/register', { username, email, password })
      .pipe(tap((res) => this.handleAuth(res)));
  }

  login(username: string, password: string) {
    return this.http
      .post<AuthResponse>('/api/auth/login', { username, password })
      .pipe(tap((res) => this.handleAuth(res)));
  }

  logout() {
    localStorage.removeItem(this.TOKEN_KEY);
    localStorage.removeItem(this.USERNAME_KEY);
    this._username.set(null);
    this._avatarUrl.set(null);
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  setCustomAvatar(base64: string) {
    const key = `${this.AVATAR_KEY_PREFIX}${this._username()!}`;
    localStorage.setItem(key, base64);
    this._avatarUrl.set(base64);
  }

  changePassword(currentPassword: string, newPassword: string) {
    return this.http.put('/api/auth/password', { currentPassword, newPassword });
  }

  changeUsername(newUsername: string) {
    return this.http
      .put<{ username: string; token: string }>('/api/auth/username', { newUsername })
      .pipe(tap((res) => this.handleAuth(res)));
  }

  changeEmail(newEmail: string) {
    return this.http.put('/api/auth/email', { newEmail });
  }

  getMe() {
    return this.http.get<{ username: string; email: string }>('/api/auth/me');
  }

  private getOrAssignAvatar(username: string): string {
    const key = `${this.AVATAR_KEY_PREFIX}${username}`;
    const stored = localStorage.getItem(key);
    if (stored) {
      // migrate old format (stored as a number like "5")
      const asNumber = parseInt(stored, 10);
      if (!isNaN(asNumber) && String(asNumber) === stored) {
        const url = this.buildBuiltinUrl(asNumber);
        localStorage.setItem(key, url);
        return url;
      }
      return stored;
    }
    const random = Math.floor(Math.random() * 36) + 1;
    const url = this.buildBuiltinUrl(random);
    localStorage.setItem(key, url);
    return url;
  }

  private buildBuiltinUrl(index: number): string {
    const ext = index === 1 ? 'png' : 'gif';
    const num = String(index).padStart(2, '0');
    return `avatars/80381876-d5f7-4a25-acff-ac0abf6196e0_${num}.${ext}`;
  }

  private handleAuth(res: AuthResponse) {
    localStorage.setItem(this.TOKEN_KEY, res.token);
    localStorage.setItem(this.USERNAME_KEY, res.username);
    this._username.set(res.username);
    this._avatarUrl.set(this.getOrAssignAvatar(res.username));
  }
}
