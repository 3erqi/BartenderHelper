import { Component, OnInit, computed, signal } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { ImageCropperComponent, ImageCroppedEvent, ImageTransform } from 'ngx-image-cropper';
import { AuthService } from '../core/auth.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-settings',
  imports: [
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatDividerModule,
    ImageCropperComponent
  ],
  templateUrl: './settings.html',
  styleUrl: './settings.scss'
})
export class Settings implements OnInit {
  email = signal('');

  // avatar cropper
  imageChangedEvent: Event | null = null;
  croppedBase64 = '';
  scale = signal(1);
  transform = computed<ImageTransform>(() => ({ scale: this.scale() }));

  // form toggles
  showPasswordForm = signal(false);
  showUsernameForm = signal(false);
  showEmailForm = signal(false);

  passwordForm: FormGroup;
  usernameForm: FormGroup;
  emailForm: FormGroup;

  passwordError = signal('');
  passwordSuccess = signal('');
  usernameError = signal('');
  usernameSuccess = signal('');
  emailError = signal('');
  emailSuccess = signal('');

  constructor(
    private fb: FormBuilder,
    protected authService: AuthService,
    private location: Location
  ) {
    this.passwordForm = this.fb.group({
      currentPassword: ['', Validators.required],
      newPassword: ['', [Validators.required, Validators.minLength(6)]]
    });
    this.usernameForm = this.fb.group({
      newUsername: ['', Validators.required]
    });
    this.emailForm = this.fb.group({
      newEmail: ['', [Validators.required, Validators.email]]
    });
  }

  ngOnInit() {
    this.authService.getMe().subscribe((me) => this.email.set(me.email));
  }

  onFileSelected(event: Event) {
    this.imageChangedEvent = event;
    this.scale.set(1);
  }

  onImageCropped(event: ImageCroppedEvent) {
    this.croppedBase64 = event.base64 ?? '';
  }

  zoomIn() {
    this.scale.update((s) => +(s + 0.1).toFixed(1));
  }

  zoomOut() {
    this.scale.update((s) => Math.max(0.1, +(s - 0.1).toFixed(1)));
  }

  saveAvatar() {
    if (this.croppedBase64) {
      this.authService.setCustomAvatar(this.croppedBase64);
      this.imageChangedEvent = null;
      this.croppedBase64 = '';
      this.scale.set(1);
    }
  }

  cancelCrop() {
    this.imageChangedEvent = null;
    this.croppedBase64 = '';
    this.scale.set(1);
  }

  changePassword() {
    if (this.passwordForm.invalid) return;
    const { currentPassword, newPassword } = this.passwordForm.value;
    this.authService.changePassword(currentPassword, newPassword).subscribe({
      next: () => {
        this.passwordSuccess.set('Password updated.');
        this.passwordError.set('');
        this.passwordForm.reset();
        this.showPasswordForm.set(false);
      },
      error: () => {
        this.passwordError.set('Current password is incorrect.');
        this.passwordSuccess.set('');
      }
    });
  }

  changeUsername() {
    if (this.usernameForm.invalid) return;
    const { newUsername } = this.usernameForm.value;
    this.authService.changeUsername(newUsername).subscribe({
      next: () => {
        this.usernameSuccess.set('Username updated.');
        this.usernameError.set('');
        this.usernameForm.reset();
        this.showUsernameForm.set(false);
      },
      error: () => {
        this.usernameError.set('Username is already taken.');
        this.usernameSuccess.set('');
      }
    });
  }

  changeEmail() {
    if (this.emailForm.invalid) return;
    const { newEmail } = this.emailForm.value;
    this.authService.changeEmail(newEmail).subscribe({
      next: () => {
        this.email.set(newEmail);
        this.emailSuccess.set('Email updated.');
        this.emailError.set('');
        this.emailForm.reset();
        this.showEmailForm.set(false);
      },
      error: () => {
        this.emailError.set('Email is already in use.');
        this.emailSuccess.set('');
      }
    });
  }

  goBack() {
    this.location.back();
  }
}
