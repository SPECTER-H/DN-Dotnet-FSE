import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { NotificationService } from '../../services/notification';

@Component({
  selector: 'app-notification',
  imports: [NgFor, NgIf],

  // Providing the service here creates a separate instance
  // for this component and its child components.
  providers: [NotificationService],

  templateUrl: './notification.html',
  styleUrl: './notification.css',
})
export class Notification {
  constructor(
    private notificationService: NotificationService,
  ) {}

  get notifications(): string[] {
    return this.notificationService.getNotifications();
  }

  addNotification(): void {
    const nextNumber = this.notifications.length + 1;

    this.notificationService.addNotification(
      `Notification ${nextNumber}`,
    );
  }
}