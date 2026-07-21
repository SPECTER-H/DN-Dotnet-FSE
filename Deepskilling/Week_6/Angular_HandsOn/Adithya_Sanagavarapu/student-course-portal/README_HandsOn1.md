# Hands-on 1 — Environment Setup, Project Structure and Components

## Objective

Set up an Angular 20 workspace, understand its generated structure, build the application and create the core components for a Student Course Portal.

## Project

```text
student-course-portal
```

The application uses Angular's standalone component architecture with routing and CSS.

## Angular Setup

The project was created using Angular CLI 20 through `npx`:

```bash
npx --yes @angular/cli@20 new student-course-portal \
  --routing \
  --style=css \
  --standalone \
  --strict \
  --skip-git \
  --package-manager=npm \
  --defaults
```

Using `npx` avoids an unnecessary global Angular CLI installation while ensuring that Angular CLI 20 is used.

## Task 1 — Project Setup and Exploration

The following files were studied and documented in `notes.txt`:

- `angular.json`
- `tsconfig.json`
- `tsconfig.app.json`
- `package.json`
- `src/main.ts`
- `src/app/app.config.ts`
- `src/app/app.ts`
- `src/index.html`

The application was successfully started with:

```bash
npx ng serve
```

The production application was built with:

```bash
npx ng build
```

The generated application was placed inside:

```text
dist/student-course-portal
```

The generated `main-*.js` file contains the compiled application code.

## Production Budgets

The following production budgets were identified in `angular.json`:

| Bundle | Warning | Error |
|---|---:|---:|
| Initial application bundle | 500 kB | 1 MB |
| Individual component stylesheet | 4 kB | 8 kB |

`maximumWarning` displays a build warning when a configured size is exceeded.

`maximumError` causes the build to fail when a configured size is exceeded.

## Task 2 — Portal Components

The following components were generated:

- Header
- Home
- Course List
- Student Profile

Each component contains:

- TypeScript component file
- HTML template
- CSS stylesheet
- Unit-test specification

Angular CLI generated the modern concise filenames such as `header.ts`, `header.html`, `header.css` and `header.spec.ts`.

## Header

The Header component displays:

- Student Course Portal
- Home navigation link
- Courses navigation link
- Profile navigation link

## Home Page

The Home component displays:

- Welcome heading
- Portal description
- 12 available courses
- 3 enrolled courses
- 3.8 GPA

## Routes

The initial routes are:

| Path | Component |
|---|---|
| `/` | Home |
| `/courses` | Course List |
| `/profile` | Student Profile |

These routes will be expanded in the later routing hands-on.

## Project Structure

```text
src/app/
├── components/
│   └── header/
│       ├── header.css
│       ├── header.html
│       ├── header.spec.ts
│       └── header.ts
├── pages/
│   ├── course-list/
│   ├── home/
│   └── student-profile/
├── app.config.ts
├── app.css
├── app.html
├── app.routes.ts
├── app.spec.ts
└── app.ts
```

## Build

```bash
npx ng build
```

## Run

```bash
npx ng serve
```

Open:

```text
http://localhost:4200
```

## Verification

The following were verified successfully:

- Angular 20 project creation
- Development server startup
- Production build
- Generated `dist` files
- Production bundle budgets
- Header navigation
- Home page content
- Portal statistics
- Home, Courses and Profile routes
- No compilation errors

## Status

**Hands-on 1 completed successfully.**