# Angular Hands-on 4 - Template-Driven Forms and Validation

## Objective

Build and validate a Student Enrollment Request form using Angular template-driven forms.

## Enrollment Route

The enrollment component is available at:

```text
/enroll
```

It is also accessible through the Enroll link in the application header.

## Task 1 - Enrollment Request Form

The form was created using Angular's `NgForm` directive.

```html
<form
  #enrollForm="ngForm"
  (ngSubmit)="onSubmit(enrollForm)"
>
```

`FormsModule` was imported into the standalone EnrollmentForm component.

### Form Fields

The form contains:

- Student name
- Student email
- Course ID
- Preferred semester
- Agreement to terms

Every form control uses a `name` attribute and `[(ngModel)]`.

### Form Submission

The submitted form value and validity are logged to the browser console.

```typescript
onSubmit(form: NgForm): void {
  console.log('Enrollment form value:', form.value);
  console.log('Enrollment form valid:', form.valid);
}
```

The Submit button is disabled while the form is invalid.

```html
<button
  type="submit"
  [disabled]="enrollForm.invalid"
>
  Submit
</button>
```

## Task 2 - Validation and Error Messages

### Student Name

Validation rules:

- Required
- Minimum length of three characters

Contextual messages are displayed when the control is touched and invalid.

### Student Email

Validation rules:

- Required
- Valid email format

### Course ID

Course ID is required.

### Terms Agreement

The terms checkbox must be selected before submission.

## Form State Styling

Angular form-state classes are used to style controls:

```css
.ng-invalid.ng-touched {
  border-color: red;
}

.ng-valid.ng-touched {
  border-color: green;
}
```

Invalid touched fields receive red borders, while valid touched fields receive green borders.

## Successful Submission

A successful valid submission displays:

```text
Enrollment request submitted successfully!
```

The success message is controlled with `*ngIf` and a `submitted` property.

## Reset

The Reset button calls:

```typescript
enrollForm.resetForm()
```

It clears:

- Form values
- Validation states
- Touched states
- Success message

## Files Added

- `pages/enrollment-form/enrollment-form.ts`
- `pages/enrollment-form/enrollment-form.html`
- `pages/enrollment-form/enrollment-form.css`
- `pages/enrollment-form/enrollment-form.spec.ts`

## Verification

```bash
npx ng build
npx ng serve
```

Verified functionality:

- Enrollment route loads correctly
- Form values use two-way binding
- Submit is disabled for invalid data
- Required-field errors appear after controls are touched
- Name minimum-length validation works
- Email-format validation works
- Terms agreement is mandatory
- Invalid and valid borders appear correctly
- Valid submission logs the form value and validity
- Success message appears after submission
- Reset clears the form and validation state
- Production build completes successfully

## Result

Angular Hands-on 4 was completed successfully using template-driven forms and built-in Angular validation.