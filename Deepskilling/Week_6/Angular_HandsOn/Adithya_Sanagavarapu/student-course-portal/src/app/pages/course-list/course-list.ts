import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { CourseCard } from '../../components/course-card/course-card';
import { Highlight } from '../../directives/highlight';
import { Course } from '../../models/course.model';
import { CourseService } from '../../services/course';

@Component({
  selector: 'app-course-list',
  imports: [NgFor, NgIf, CourseCard, Highlight],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css',
})
export class CourseList implements OnInit {
  isLoading = true;
  selectedCourseId: number | null = null;
  courses: Course[] = [];

  constructor(private courseService: CourseService) {}

  ngOnInit(): void {
    this.courses = this.courseService.getCourses();

    setTimeout(() => {
      this.isLoading = false;
    }, 1500);
  }

  onEnroll(courseId: number): void {
    this.selectedCourseId = courseId;

    console.log(
      `Enrollment selection changed for course: ${courseId}`,
    );
  }

  trackByCourseId(index: number, course: Course): number {
    return course.id;
  }
}