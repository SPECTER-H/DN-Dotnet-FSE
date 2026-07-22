import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
} from '@angular/forms';

function noCourseCode(
  control: AbstractControl,
): ValidationErrors | null {
  const courseCode = control.value as string | null;

  if (courseCode?.startsWith('XX')) {
    return {
      noCourseCode: true,
    };
  }

  return null;
}

function simulateEmailCheck(
  control: AbstractControl,
): Promise<ValidationErrors | null> {
  return new Promise((resolve) => {
    setTimeout(() => {
      const email = control.value as string | null;

      if (email?.includes('test@')) {
        resolve({
          emailTaken: true,
        });
      } else {
        resolve(null);
      }
    }, 800);
  });
}

@Component({
  selector: 'app-reactive-enrollment-form',
  imports: [
    NgFor,
    NgIf,
    ReactiveFormsModule,
  ],
  templateUrl: './reactive-enrollment-form.html',
  styleUrl: './reactive-enrollment-form.css',
})
export class ReactiveEnrollmentForm
  implements OnInit
{
  enrollForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
  ) {}

  ngOnInit(): void {
    this.enrollForm = this.formBuilder.group({
      studentName: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
        ],
      ],

      studentEmail: this.formBuilder.control(
        '',
        [
          Validators.required,
          Validators.email,
        ],
        [simulateEmailCheck],
      ),

      courseId: [
        '',
        [
          Validators.required,
          noCourseCode,
        ],
      ],

      preferredSemester: [
        'Odd',
        Validators.required,
      ],

      agreeToTerms: [
        false,
        Validators.requiredTrue,
      ],

      additionalCourses:
        this.formBuilder.array([]),
    });
  }

  get additionalCourses(): FormArray {
    return this.enrollForm.get(
      'additionalCourses',
    ) as FormArray;
  }

  addCourse(): void {
    this.additionalCourses.push(
      new FormControl(
        '',
        Validators.required,
      ),
    );
  }

  removeCourse(index: number): void {
    this.additionalCourses.removeAt(index);
  }

  onSubmit(): void {
    if (this.enrollForm.invalid) {
      return;
    }

    console.log(
      'Form value:',
      this.enrollForm.value,
    );

    console.log(
      'Raw form value:',
      this.enrollForm.getRawValue(),
    );

    this.enrollForm.markAsPristine();
  }

  hasUnsavedChanges(): boolean {
    return this.enrollForm?.dirty ?? false;
  }
}