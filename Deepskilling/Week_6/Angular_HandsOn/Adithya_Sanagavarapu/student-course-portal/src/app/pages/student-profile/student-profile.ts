import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { Course } from '../../models/course.model';
import { EnrollmentService } from '../../services/enrollment';

@Component({
  selector: 'app-student-profile',
  imports: [NgFor, NgIf],
  templateUrl: './student-profile.html',
  styleUrl: './student-profile.css',
})
export class StudentProfile {
  constructor(
    private enrollmentService: EnrollmentService,
  ) {}

  get enrolledCourses(): Course[] {
    return this.enrollmentService.getEnrolledCourses();
  }
}