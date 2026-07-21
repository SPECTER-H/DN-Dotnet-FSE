import { Injectable } from '@angular/core';

@Injectable()
export class NotificationService {
  private notifications: string[] = [];

  getNotifications(): string[] {
    return this.notifications;
  }

  addNotification(message: string): void {
    this.notifications.push(message);
  }
}