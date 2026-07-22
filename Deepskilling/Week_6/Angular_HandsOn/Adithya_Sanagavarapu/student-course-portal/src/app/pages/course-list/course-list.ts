import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {
  ActivatedRoute,
  Router,
} from '@angular/router';
import { CourseCard } from '../../components/course-card/course-card';
import { Highlight } from '../../directives/highlight';
import { Course } from '../../models/course.model';
import { CourseService } from '../../services/course';

@Component({
  selector: 'app-course-list',
  imports: [
    NgFor,
    NgIf,
    FormsModule,
    CourseCard,
    Highlight,
  ],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css',
})
export class CourseList implements OnInit {
  isLoading = true;
  selectedCourseId: number | null = null;
  searchTerm = '';
  courses: Course[] = [];

  constructor(
    private courseService: CourseService,
    private router: Router,
    private route: ActivatedRoute,
  ) {}

  get filteredCourses(): Course[] {
    const search = this.searchTerm
      .trim()
      .toLowerCase();

    if (!search) {
      return this.courses;
    }

    return this.courses.filter(
      (course) =>
        course.name.toLowerCase().includes(search) ||
        course.code.toLowerCase().includes(search),
    );
  }

  ngOnInit(): void {
    this.searchTerm =
      this.route.snapshot.queryParamMap.get('search') ??
      '';

    this.courses = this.courseService.getCourses();

    setTimeout(() => {
      this.isLoading = false;
    }, 1500);
  }

  updateSearch(): void {
    const search = this.searchTerm.trim();

    void this.router.navigate(['courses'], {
      queryParams: {
        search: search || null,
      },
    });
  }

  openCourseDetails(courseId: number): void {
    void this.router.navigate([
      'courses',
      courseId,
    ]);
  }

  onEnroll(courseId: number): void {
    this.selectedCourseId = courseId;

    console.log(
      `Enrollment selection changed for course: ${courseId}`,
    );
  }

  trackByCourseId(
    index: number,
    course: Course,
  ): number {
    return course.id;
  }
}