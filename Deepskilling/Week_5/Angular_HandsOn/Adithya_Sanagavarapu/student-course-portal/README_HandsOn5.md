# Angular Hands-on 5 - Reactive Forms

## Objective

Rebuild the enrollment form using Angular Reactive Forms and implement built-in validators, custom synchronous and asynchronous validators, and dynamic form controls.

## Reactive Enrollment Route

The reactive form is available at:

```text
/enroll-reactive
```

## Task 1 - FormBuilder and FormGroup

`ReactiveFormsModule` was imported into the standalone component.

The form model is created in TypeScript using `FormBuilder` and `FormGroup`.

```typescript
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
    [
      simulateEmailCheck,
    ],
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
  additionalCourses: this.formBuilder.array([]),
});
```

The template binds the form using:

```html
<form [formGroup]="enrollForm">
```

Individual fields use `formControlName`.

Reactive forms do not require `ngModel` because the form model is maintained entirely in TypeScript.

## Built-in Validators

The form uses:

- `Validators.required`
- `Validators.minLength(3)`
- `Validators.email`
- `Validators.requiredTrue`

The Submit button remains disabled while the form is invalid or an asynchronous validator is pending.

## Form Value and Raw Value

On successful submission, the component logs:

```typescript
this.enrollForm.value
```

and:

```typescript
this.enrollForm.getRawValue()
```

`value` excludes disabled controls, while `getRawValue()` includes all controls.

## Task 2 - Custom Validators

### Synchronous Course Validator

The `noCourseCode` validator rejects course codes beginning with `XX`.

Example:

```text
XX101
```

produces:

```text
Course code starting with XX is not allowed.
```

### Asynchronous Email Validator

`simulateEmailCheck` waits 800 milliseconds before resolving.

An email containing:

```text
test@
```

returns the `emailTaken` validation error.

Example:

```text
test@example.com
```

produces:

```text
Email is already taken
```

Asynchronous validation runs after the synchronous validators pass.

## Dynamic FormArray

A `FormArray` stores additional course controls.

```typescript
get additionalCourses(): FormArray {
  return this.enrollForm.get(
    'additionalCourses',
  ) as FormArray;
}
```

The typed getter keeps the cast in TypeScript instead of casting repeatedly in the template.

### Add Course

```typescript
this.additionalCourses.push(
  new FormControl('', Validators.required),
);
```

### Remove Course

```typescript
this.additionalCourses.removeAt(index);
```

Users can add or remove additional course codes dynamically.

## Files Added

- `pages/reactive-enrollment-form/reactive-enrollment-form.ts`
- `pages/reactive-enrollment-form/reactive-enrollment-form.html`
- `pages/reactive-enrollment-form/reactive-enrollment-form.css`
- `pages/reactive-enrollment-form/reactive-enrollment-form.spec.ts`

## Verification

```bash
npx ng build
npx ng serve
```

Verified functionality:

- Reactive enrollment route loads correctly
- Form is constructed using FormBuilder
- Template binds using FormGroup and formControlName
- Built-in validation rules work
- Terms checkbox uses requiredTrue
- Submit remains disabled for invalid or pending forms
- Course codes beginning with XX are rejected
- Taken email validation appears after 800 milliseconds
- Additional course controls can be added
- Additional course controls can be removed
- Form value and raw value are logged
- Production build completes successfully

## Result

Angular Hands-on 5 was completed successfully using Reactive Forms, custom validators, asynchronous validation, and FormArray.