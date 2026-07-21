# Angular Hands-on 6 - Services and Dependency Injection

## Objective

Use Angular services to centralize course and enrollment data, demonstrate service-to-service injection, share singleton state, and demonstrate component-level dependency injection.

## Task 1 - CourseService

`CourseService` is provided at the root level:

```typescript
@Injectable({
  providedIn: 'root',
})
```

This creates one singleton service instance shared across the application.

### CourseService Operations

The service provides:

- `getCourses()`
- `getCourseById()`
- `addCourse()`

Course data was moved out of CourseList and into the service.

### Shared Course Data

The same CourseService is injected into:

- CourseList
- Home
- CourseSummaryWidget

Home and CourseSummaryWidget both display the live course count.

Adding a course through CourseSummaryWidget immediately updates both counts and the CourseList, proving that all components share the same root service instance.

### Course Model

The shared Course interface is defined in:

```text
models/course.model.ts
```

It provides compile-time type checking throughout the application.

## Task 2 - EnrollmentService

`EnrollmentService` stores enrolled course IDs and provides:

- `enroll(courseId)`
- `unenroll(courseId)`
- `isEnrolled(courseId)`
- `getEnrolledCourses()`

### Service-to-Service Injection

EnrollmentService injects CourseService to resolve course IDs into complete Course objects.

```typescript
constructor(private courseService: CourseService) {}
```

### CourseCard Integration

CourseCard injects EnrollmentService.

The Enroll button changes to Unenroll after enrollment and returns to Enroll after unenrollment.

### Student Profile Integration

StudentProfile injects EnrollmentService and displays all currently enrolled courses.

Enrollment state remains available when navigating between Courses and Student Profile because EnrollmentService is a root-level singleton.

## Hierarchical Dependency Injection

NotificationService is provided directly in the Notification component:

```typescript
providers: [NotificationService]
```

A component-level provider creates a separate service instance for that component and its children.

Two Notification components are displayed on Home. Adding a notification to one component does not affect the other, demonstrating isolated component-scoped service instances.

## Files Added

- `services/course.ts`
- `services/course.spec.ts`
- `services/enrollment.ts`
- `services/enrollment.spec.ts`
- `services/notification.ts`
- `services/notification.spec.ts`
- `components/course-summary-widget/`
- `components/notification/`
- `models/course.model.ts`

## Verification

```bash
npx ng build
npx ng serve
```

Verified functionality:

- Course data is provided by CourseService
- Home displays the live course count
- CourseSummaryWidget displays the same count
- Adding a course updates all service consumers
- EnrollmentService injects CourseService
- Enroll and Unenroll toggle correctly
- Enrolled courses appear in Student Profile
- Unenrolled courses disappear from Student Profile
- Notification components have independent service state
- Production build completes successfully

## Result

Angular Hands-on 6 was completed successfully using root-level services, shared singleton state, service-to-service injection, and hierarchical dependency injection.