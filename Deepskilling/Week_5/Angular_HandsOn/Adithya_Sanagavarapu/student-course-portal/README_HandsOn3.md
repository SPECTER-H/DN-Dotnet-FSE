# Angular Hands-on 3 - Directives and Pipes

## Objective

Use Angular structural directives, attribute directives, a custom directive, and a custom pipe in the Student Course Portal.

## Task 1 - Structural Directives

### Loading State with ngIf

The course list displays a loading message for 1.5 seconds before rendering the courses.

```html
<p *ngIf="isLoading">
  Loading courses...
</p>
```

### Rendering Courses with ngFor

Five course cards are rendered using `*ngFor`.

```html
<app-course-card
  *ngFor="
    let course of courses;
    let i = index;
    trackBy: trackByCourseId
  "
  [course]="course"
></app-course-card>
```

### trackBy

`trackByCourseId()` returns the unique course ID so Angular only updates changed course elements.

```typescript
trackByCourseId(index: number, course: Course): number {
  return course.id;
}
```

### Grade Status with ngSwitch

CourseCard uses `ngSwitch` to display:

- Green Passed badge
- Red Failed badge
- Grey Pending badge

### Empty Course Template

An `ng-template` displays the following message when the course list is empty:

```text
No courses available.
```

## Task 2 - Attribute Directives

### ngClass

Conditional classes are applied using a component getter.

```typescript
get cardClasses(): Record<string, boolean> {
  return {
    'card-enrolled': this.course.enrolled,
    'card-full': (this.course.credits ?? 0) >= 4,
    expanded: this.isExpanded,
  };
}
```

The classes represent:

- `card-enrolled` - the student enrolled in the course
- `card-full` - the course has four or more credits
- `expanded` - additional course details are visible

### ngStyle

The left border colour is selected dynamically from `gradeStatus`:

- Green for passed
- Red for failed
- Grey for pending

### Expandable Cards

The Show Details button toggles the `expanded` class and displays additional course information.

## Task 3 - Custom Directive and Pipe

### Highlight Directive

The custom `appHighlight` directive uses `@HostListener` to respond to mouse events.

```typescript
@HostListener('mouseenter')
onMouseEnter(): void {
  this.setBackgroundColor(this.appHighlight);
}

@HostListener('mouseleave')
onMouseLeave(): void {
  this.setBackgroundColor('');
}
```

The directive has a default yellow colour and accepts a configurable colour through `@Input()`.

```html
<app-course-card appHighlight="lightblue">
</app-course-card>
```

### Credit Label Pipe

The custom `creditLabel` pipe transforms credit values into readable labels.

| Input | Output |
|---:|---|
| `1` | `1 Credit` |
| `3` | `3 Credits` |
| `null` or `0` | `No Credits` |

Usage:

```html
{{ course.credits | creditLabel }}
```

## Files Added

- `directives/highlight.ts`
- `directives/highlight.spec.ts`
- `pipes/credit-label-pipe.ts`
- `pipes/credit-label-pipe.spec.ts`

## Verification

```bash
npx ng build
npx ng serve
```

Verified functionality:

- Loading message appears for approximately 1.5 seconds
- Five courses are rendered using `*ngFor`
- `trackBy` uses each course ID
- Correct grade badge appears through `ngSwitch`
- Empty-list template is implemented
- Enrollment and full-course classes are applied through `ngClass`
- Grade border colours are applied through `ngStyle`
- Show Details expands and collapses cards
- Hovering applies the configurable highlight colour
- Credit values use singular, plural, and no-credit labels
- Production build completes successfully

## Result

Angular Hands-on 3 was completed successfully using built-in and custom directives and a custom pipe.