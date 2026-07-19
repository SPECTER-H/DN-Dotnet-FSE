import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  Output,
  SimpleChanges,
} from '@angular/core';
import { Course } from '../../models/course';

@Component({
  selector: 'app-course-card',
  imports: [],
  templateUrl: './course-card.html',
  styleUrl: './course-card.css',
})
export class CourseCard implements OnChanges {
  @Input() course!: Course;

  @Output() enrollRequested = new EventEmitter<number>();

  ngOnChanges(changes: SimpleChanges): void {
    const courseChange = changes['course'];

    if (courseChange) {
      console.log('Course input changed');
      console.log('Previous value:', courseChange.previousValue);
      console.log('Current value:', courseChange.currentValue);
    }
  }

  requestEnrollment(): void {
    this.enrollRequested.emit(this.course.id);
  }
}