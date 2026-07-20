import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { CourseCard } from '../../components/course-card/course-card';
import { Highlight } from '../../directives/highlight';
import { Course } from '../../models/course';

@Component({
  selector: 'app-course-list',
  imports: [NgFor, NgIf, CourseCard, Highlight],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css',
})
export class CourseList implements OnInit {
  isLoading = true;
  selectedCourseId: number | null = null;

  courses: Course[] = [
    {
      id: 1,
      name: 'Angular',
      code: 'ANG101',
      credits: 1,
      gradeStatus: 'passed',
      enrolled: false,
    },
    {
      id: 2,
      name: 'ASP.NET Core Web API',
      code: 'NET201',
      credits: 3,
      gradeStatus: 'pending',
      enrolled: false,
    },
    {
      id: 3,
      name: 'Entity Framework Core',
      code: 'EFC201',
      credits: null,
      gradeStatus: 'failed',
      enrolled: false,
    },
    {
      id: 4,
      name: 'Microservices',
      code: 'MIC301',
      credits: 4,
      gradeStatus: 'passed',
      enrolled: false,
    },
    {
      id: 5,
      name: 'Advanced SQL Server',
      code: 'SQL201',
      credits: 3,
      gradeStatus: 'pending',
      enrolled: false,
    },
  ];

  ngOnInit(): void {
    setTimeout(() => {
      this.isLoading = false;
    }, 1500);
  }

  onEnroll(courseId: number): void {
    this.selectedCourseId = courseId;

    const selectedCourse = this.courses.find(
      (course) => course.id === courseId,
    );

    if (selectedCourse) {
      selectedCourse.enrolled = true;
    }

    console.log(`Enrolling in course: ${courseId}`);
  }

  trackByCourseId(index: number, course: Course): number {
    // trackBy prevents Angular from recreating unchanged course cards.
    return course.id;
  }
}