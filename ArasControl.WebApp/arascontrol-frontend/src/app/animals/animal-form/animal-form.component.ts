// animal-form.component.ts
import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AnimalService } from '../animal-service';
import { AuthService } from '../../auth/auth.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, DateAdapter, NativeDateAdapter, MAT_DATE_FORMATS, MAT_NATIVE_DATE_FORMATS } from '@angular/material/core';

@Component({
  selector: 'app-animal-form',
  templateUrl: './animal-form.component.html',
  styleUrls: ['./animal-form.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [{ provide: DateAdapter, useClass: NativeDateAdapter }, { provide: MAT_DATE_FORMATS, useValue: MAT_NATIVE_DATE_FORMATS },],
})
export class AnimalFormComponent {
  form: FormGroup;
  constructor(
    private fb: FormBuilder,
    private animalService: AnimalService,
    private dialogRef: MatDialogRef<AnimalFormComponent>,
    private authService: AuthService,
    @Inject(MAT_DIALOG_DATA,) public data: any
  ) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      breed: [''],
      gender: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      microchipId: [''],
      registrationNumber: [''],
      temperament: [''],
      color:[''],
      weightKg: [''],
      heightCm: [''],
      medicalHistory: [''],
    });
  }

  onSubmit() {
    if (this.form.valid) {
      const ownerId = this.authService.getOwnerId();
      const harasId = this.authService.getHarasId();
      console.log('Owner ID:', ownerId);
      console.log('Haras ID:', harasId);
      if (!ownerId || !harasId) {
        alert('Não foi possível identificar o Haras ou o proprietário.');
        return;
      }
      if (this.form.valid) {
        const payload = {
          ...this.form.value,
              ownerId,       // Inclui ownerId aqui
        harasId,
          dateOfBirth: this.form.value.dateOfBirth
            ? this.form.value.dateOfBirth.toISOString()
            : null,
        };
        this.animalService.create(payload).subscribe(() => {
          this.dialogRef.close(true);
        });
      }
    }
  }

  onCancel() {
    this.dialogRef.close();
  }
}