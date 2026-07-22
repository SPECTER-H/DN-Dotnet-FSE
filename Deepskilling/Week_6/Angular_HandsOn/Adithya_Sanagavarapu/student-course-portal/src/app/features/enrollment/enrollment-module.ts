import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { EnrollmentForm } from './pages/enrollment-form/enrollment-form';
import { ReactiveEnrollmentForm } from './pages/reactive-enrollment-form/reactive-enrollment-form';
import { EnrollmentRoutingModule } from './enrollment-routing-module';

@NgModule({
  imports: [
    CommonModule,
    EnrollmentRoutingModule,
    EnrollmentForm,
    ReactiveEnrollmentForm,
  ],
})
export class EnrollmentModule {}