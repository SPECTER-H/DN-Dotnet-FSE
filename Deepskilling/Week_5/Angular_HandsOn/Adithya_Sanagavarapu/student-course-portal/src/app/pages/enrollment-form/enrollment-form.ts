import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-enrollment-form',
  imports: [FormsModule, NgIf],
  templateUrl: './enrollment-form.html',
  styleUrl: './enrollment-form.css',
})
export class EnrollmentForm {
  submitted = false;

  enrollment = {
    studentName: '',
    studentEmail: '',
    courseId: null as number | null,
    preferredSemester: '',
    agreeToTerms: false,
  };

  onSubmit(form: NgForm): void {
    console.log('Enrollment form value:', form.value);
    console.log('Enrollment form valid:', form.valid);

    if (form.invalid) {
      return;
    }

    this.submitted = true;
  }
}