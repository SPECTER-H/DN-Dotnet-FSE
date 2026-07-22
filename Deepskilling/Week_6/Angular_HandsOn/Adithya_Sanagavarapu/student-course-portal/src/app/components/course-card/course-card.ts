import {
  NgClass,
  NgStyle,
  NgSwitch,
  NgSwitchCase,
  NgSwitchDefault,
} from '@angular/common';
import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  Output,
  SimpleChanges,
} from '@angular/core';
import { Course } from '../../models/course.model';
import { CreditLabelPipe } from '../../pipes/credit-label-pipe';
import { EnrollmentService } from '../../services/enrollment';

@Component({
  selector: 'app-course-card',
  imports: [
    NgClass,
    NgStyle,
    NgSwitch,
    NgSwitchCase,
    NgSwitchDefault,
    CreditLabelPipe,
  ],
  templateUrl: './course-card.html',
  styleUrl: './course-card.css',
})
export class CourseCard implements OnChanges {
  @Input() course!: Course;

  @Output() enrollRequested =
    new EventEmitter<number>();

  isExpanded = false;

  constructor(
    private enrollmentService: EnrollmentService,
  ) {}

  get isEnrolled(): boolean {
    return this.enrollmentService.isEnrolled(
      this.course.id,
    );
  }

  get cardClasses(): Record<string, boolean> {
    return {
      'card-enrolled': this.isEnrolled,
      'card-full':
        (this.course.credits ?? 0) >= 4,
      expanded: this.isExpanded,
    };
  }

  ngOnChanges(changes: SimpleChanges): void {
    const courseChange = changes['course'];

    if (courseChange) {
      console.log('Course input changed');
      console.log(
        'Previous value:',
        courseChange.previousValue,
      );
      console.log(
        'Current value:',
        courseChange.currentValue,
      );
    }
  }

  toggleEnrollment(event: MouseEvent): void {
    event.stopPropagation();

    if (this.isEnrolled) {
      this.enrollmentService.unenroll(
        this.course.id,
      );
    } else {
      this.enrollmentService.enroll(
        this.course.id,
      );
    }

    this.enrollRequested.emit(this.course.id);
  }

  toggleDetails(event: MouseEvent): void {
    event.stopPropagation();
    this.isExpanded = !this.isExpanded;
  }
}