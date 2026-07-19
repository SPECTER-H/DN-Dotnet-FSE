import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { CourseCard } from '../../components/course-card/course-card';
import { Course } from '../../models/course';

@Component({
  selector: 'app-course-list',
  imports: [NgFor, NgIf, CourseCard],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css',
})
export class CourseList {
  courses: Course[] = [
    {
      id: 1,
      name: 'Angular',
      code: 'ANG101',
      credits: 4,
    },
    {
      id: 2,
      name: 'ASP.NET Core Web API',
      code: 'NET201',
      credits: 4,
    },
    {
      id: 3,
      name: 'Entity Framework Core',
      code: 'EFC201',
      credits: 3,
    },
    {
      id: 4,
      name: 'Microservices',
      code: 'MIC301',
      credits: 4,
    },
    {
      id: 5,
      name: 'Advanced SQL Server',
      code: 'SQL201',
      credits: 3,
    },
  ];

  selectedCourseId: number | null = null;

  onEnroll(courseId: number): void {
    this.selectedCourseId = courseId;
    console.log(`Enrollment requested for course ID: ${courseId}`);
  }
}