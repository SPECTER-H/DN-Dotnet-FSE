import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course } from '../../models/course.model';
import { CreditLabelPipe } from '../../pipes/credit-label-pipe';
import { CourseService } from '../../services/course';

@Component({
  selector: 'app-course-detail',
  imports: [NgIf, CreditLabelPipe],
  templateUrl: './course-detail.html',
  styleUrl: './course-detail.css',
})
export class CourseDetail implements OnInit {
  course: Course | undefined;

  constructor(
    private route: ActivatedRoute,
    private courseService: CourseService,
  ) {}

  ngOnInit(): void {
    const courseId = Number(
      this.route.snapshot.paramMap.get('id'),
    );

    if (Number.isInteger(courseId)) {
      this.course =
        this.courseService.getCourseById(courseId);
    }
  }
}