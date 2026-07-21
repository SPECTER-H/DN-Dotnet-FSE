import { Injectable } from '@angular/core';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  private courses: Course[] = [
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

  getCourses(): Course[] {
    return this.courses;
  }

  getCourseById(id: number): Course | undefined {
    return this.courses.find(
      (course) => course.id === id,
    );
  }

  addCourse(course: Course): void {
    this.courses.push(course);
  }
}