import { Routes } from '@angular/router';
import { authGuard } from './guards/auth-guard';
import { CourseDetail } from './pages/course-detail/course-detail';
import { CourseList } from './pages/course-list/course-list';
import { CoursesLayout } from './pages/courses-layout/courses-layout';
import { Home } from './pages/home/home';
import { NotFound } from './pages/not-found/not-found';
import { StudentProfile } from './pages/student-profile/student-profile';

export const routes: Routes = [
  {
    path: '',
    component: Home,
  },
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
  },
  {
    path: 'profile',
    component: StudentProfile,
    canActivate: [authGuard],
  },
  {
    path: 'enroll',
    canActivate: [authGuard],
    loadChildren: () =>
      import(
        './features/enrollment/enrollment-module'
      ).then(
        (module) => module.EnrollmentModule,
      ),
  },
  {
    path: '**',
    component: NotFound,
  },
];