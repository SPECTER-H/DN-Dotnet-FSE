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
import { Course } from '../../models/course';
import { CreditLabelPipe } from '../../pipes/credit-label-pipe';

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

  @Output() enrollRequested = new EventEmitter<number>();

  isExpanded = false;

  get cardClasses(): Record<string, boolean> {
    // Keeping conditional class logic here keeps the template clean.
    return {
      'card-enrolled': this.course.enrolled,
      'card-full': (this.course.credits ?? 0) >= 4,
      expanded: this.isExpanded,
    };
  }

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

  toggleDetails(): void {
    this.isExpanded = !this.isExpanded;
  }
}