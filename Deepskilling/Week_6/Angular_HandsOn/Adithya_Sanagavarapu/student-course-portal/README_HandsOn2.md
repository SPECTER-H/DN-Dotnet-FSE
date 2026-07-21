# Angular Hands-on 2 - Binding, Lifecycle Hooks and Component Communication

## Objective

Implement Angular data binding, lifecycle hooks, structural directives, and communication between parent and child components.

## Task 1 - Data Binding

The Home component demonstrates the four primary forms of Angular data binding.

### Interpolation

The portal name is displayed using interpolation.

```html
<h1>{{ portalName }}</h1>
```

### Property Binding

The Enroll button's disabled state is controlled by the component.

```html
<button [disabled]="!isPortalActive">
  Enroll Now
</button>
```

### Event Binding

Clicking the Enroll button calls a component method.

```html
<button (click)="onEnrollClick()">
  Enroll Now
</button>
```

### Two-way Binding

The course search input uses `ngModel` to synchronize the view and component value.

```html
<input [(ngModel)]="searchTerm" />
```

`FormsModule` was imported into the standalone Home component to support `ngModel`.

## Task 2 - Lifecycle Hooks and Input Binding

### OnInit

`ngOnInit()` simulates loading the available course count and logs when the Home component is initialized.

```typescript
ngOnInit(): void {
  this.courseCount = 3;
  console.log('HomeComponent initialised — courses loaded');
}
```

### OnDestroy

`ngOnDestroy()` logs when navigation destroys the Home component.

```typescript
ngOnDestroy(): void {
  console.log('HomeComponent destroyed');
}
```

### OnChanges

The CourseCard component uses `ngOnChanges()` to log previous and current course input values.

```typescript
ngOnChanges(changes: SimpleChanges): void {
  const courseChange = changes['course'];

  if (courseChange) {
    console.log('Previous value:', courseChange.previousValue);
    console.log('Current value:', courseChange.currentValue);
  }
}
```

## Task 3 - Component Communication

### Course Model

A strongly typed `Course` interface contains:

- ID
- Name
- Course code
- Credits

### Parent-to-child Communication

The CourseList component passes each course to CourseCard using `@Input()`.

```html
<app-course-card
  [course]="course"
></app-course-card>
```

### Child-to-parent Communication

CourseCard emits the selected course ID using `@Output()` and `EventEmitter`.

```typescript
@Output() enrollRequested = new EventEmitter<number>();
```

The parent handles the emitted event:

```html
(enrollRequested)="onEnroll($event)"
```

## Structural Directives

`*ngFor` renders all five courses:

```html
<app-course-card
  *ngFor="let course of courses"
  [course]="course"
></app-course-card>
```

`*ngIf` displays the enrollment result only after a course is selected:

```html
<p *ngIf="selectedCourseId !== null">
  Enrollment requested for course ID:
  {{ selectedCourseId }}
</p>
```

## Components and Files

- `pages/home` - demonstrates data binding and lifecycle hooks
- `pages/course-list` - stores courses and handles enrollment events
- `components/course-card` - receives course data and emits enrollment requests
- `models/course.ts` - strongly typed Course interface

## Verification

```bash
npx ng build
npx ng serve
```

Verified functionality:

- Portal name displays through interpolation
- Enroll button uses property and event binding
- Search field uses two-way binding
- Lifecycle messages appear in the browser console
- Five strongly typed courses are rendered
- CourseCard receives data through `@Input()`
- Enrollment events are emitted through `@Output()`
- Selected course ID appears after enrollment
- Production build completes successfully

## Result

Angular Hands-on 2 was completed successfully using standalone Angular components.