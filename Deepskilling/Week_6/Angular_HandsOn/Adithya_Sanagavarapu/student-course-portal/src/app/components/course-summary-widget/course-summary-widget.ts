import { Component } from '@angular/core';
import { CourseService } from '../../services/course';

@Component({
  selector: 'app-course-summary-widget',
  imports: [],
  templateUrl: './course-summary-widget.html',
  styleUrl: './course-summary-widget.css',
})
export class CourseSummaryWidget {
  constructor(private courseService: CourseService) {}

  get courseCount(): number {
    return this.courseService.getCourses().length;
  }

  addSampleCourse(): void {
    const courses = this.courseService.getCourses();

    const nextId =
      Math.max(
        ...courses.map((course) => course.id),
        0,
      ) + 1;

    this.courseService.addCourse({
      id: nextId,
      name: `New Course ${nextId}`,
      code: `NEW${nextId}`,
      credits: 2,
      gradeStatus: 'pending',
      enrolled: false,
    });
  }
}