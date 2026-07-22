import { NgModule } from '@angular/core';
import {
  RouterModule,
  Routes,
} from '@angular/router';
import { unsavedChangesGuard } from '../../guards/unsaved-changes-guard';
import { EnrollmentForm } from './pages/enrollment-form/enrollment-form';
import { ReactiveEnrollmentForm } from './pages/reactive-enrollment-form/reactive-enrollment-form';

const routes: Routes = [
  {
    path: '',
    component: EnrollmentForm,
    canDeactivate: [unsavedChangesGuard],
  },
  {
    path: 'reactive',
    component: ReactiveEnrollmentForm,
    canDeactivate: [unsavedChangesGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EnrollmentRoutingModule {}