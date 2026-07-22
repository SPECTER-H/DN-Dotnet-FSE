# Angular Hands-on 7 - Routing, Lazy Loading and Guards

## Objective

Implement advanced Angular routing features in the Student Course Portal, including route parameters, query parameters, nested routes, lazy loading and route guards.

## Task 1 - Route Configuration and Parameters

### Routes Implemented

| Route | Component |
|---|---|
| `/` | Home |
| `/courses` | Course List |
| `/courses/:id` | Course Detail |
| `/profile` | Student Profile |
| `/enroll` | Template-driven Enrollment Form |
| `/enroll/reactive` | Reactive Enrollment Form |
| Any unknown route | 404 Not Found |

### Route Parameters

The Course Detail component reads the course ID using `ActivatedRoute`.

```typescript
const courseId = Number(
  this.route.snapshot.paramMap.get('id'),
);
```

The course is retrieved using:

```typescript
this.courseService.getCourseById(courseId);
```

Selecting a course card navigates to its detail page.

```typescript
this.router.navigate([
  'courses',
  courseId,
]);
```

### Query Parameters

The course search value is written to the URL as a query parameter.

```typescript
this.router.navigate(['courses'], {
  queryParams: {
    search: this.searchTerm,
  },
});
```

It is read during initialization using:

```typescript
this.route.snapshot.queryParamMap.get('search');
```

Example:

```text
/courses?search=angular
```

### Nested Routes

The Course List and Course Detail routes are children of the Courses Layout route.

```typescript
{
  path: 'courses',
  component: CoursesLayout,
  children: [
    {
      path: '',
      component: CourseList,
    },
    {
      path: ':id',
      component: CourseDetail,
    },
  ],
}
```

`CoursesLayout` contains a child router outlet.

```html
<router-outlet></router-outlet>
```

### Wildcard Route

Unknown URLs display the generated Not Found component.

```typescript
{
  path: '**',
  component: NotFound,
}
```

## Task 2 - Lazy Loading and Route Guards

### Enrollment Feature Module

The template-driven and reactive enrollment forms were moved into the enrollment feature.

```text
features/
└── enrollment/
    ├── pages/
    │   ├── enrollment-form/
    │   └── reactive-enrollment-form/
    ├── enrollment-module.ts
    └── enrollment-routing-module.ts
```

### Lazy Loading

The enrollment feature is loaded only when the user navigates to `/enroll`.

```typescript
{
  path: 'enroll',
  canActivate: [authGuard],
  loadChildren: () =>
    import(
      './features/enrollment/enrollment-module'
    ).then(
      (module) => module.EnrollmentModule,
    ),
}
```

A separate enrollment JavaScript chunk is generated during the Angular build.

### Authentication Guard

The authentication guard checks the hardcoded `AuthService.isLoggedIn` value.

- Authenticated users can access `/profile` and `/enroll`.
- Unauthenticated users are redirected to `/`.

```typescript
if (authService.isLoggedIn) {
  return true;
}

router.navigate(['/']);
return false;
```

### Unsaved Changes Guard

Both enrollment forms implement a `hasUnsavedChanges()` method.

```typescript
hasUnsavedChanges(): boolean {
  return this.enrollForm?.dirty ?? false;
}
```

When a user attempts to leave a dirty form, the guard displays:

```text
You have unsaved changes. Leave?
```

Successfully submitting a valid form marks it as pristine, allowing navigation without displaying the confirmation.

## Verification

The following behavior was tested:

- `/courses/2` displays the correct course.
- Clicking a course card opens the detail route.
- Course search updates the URL query parameter.
- Unknown URLs display the 404 page.
- Enrollment routes are loaded lazily.
- Protected routes respond to authentication state.
- Dirty enrollment forms display a confirmation before navigation.
- Submitted or pristine forms allow navigation normally.

## Build and Run

```bash
npx ng build
npx ng serve
```

## Result

Advanced Angular routing, lazy loading, authentication protection and unsaved-form protection were implemented successfully.