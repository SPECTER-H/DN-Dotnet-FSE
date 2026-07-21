import { Injectable } from '@angular/core';
import { Course } from '../models/course.model';
import { CourseService } from './course';

@Injectable({
  providedIn: 'root',
})
export class EnrollmentService {
  private enrolledCourseIds: number[] = [];

  constructor(private courseService: CourseService) {}

  enroll(courseId: number): void {
    if (!this.enrolledCourseIds.includes(courseId)) {
      this.enrolledCourseIds.push(courseId);
    }

    const course =
      this.courseService.getCourseById(courseId);

    if (course) {
      course.enrolled = true;
    }
  }

  unenroll(courseId: number): void {
    this.enrolledCourseIds =
      this.enrolledCourseIds.filter(
        (id) => id !== courseId,
      );

    const course =
      this.courseService.getCourseById(courseId);

    if (course) {
      course.enrolled = false;
    }
  }

  isEnrolled(courseId: number): boolean {
    return this.enrolledCourseIds.includes(courseId);
  }

  getEnrolledCourses(): Course[] {
    return this.enrolledCourseIds
      .map((id) => this.courseService.getCourseById(id))
      .filter(
        (course): course is Course =>
          course !== undefined,
      );
  }
}