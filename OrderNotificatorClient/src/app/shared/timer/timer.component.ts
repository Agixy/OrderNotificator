import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription, timer } from 'rxjs';

@Component({
  selector: 'timer',
  templateUrl: './timer.component.html',
  standalone: true
})
export class TimerComponent implements OnInit, OnDestroy {
  @Input() endTime?: Date;

  displayTime: string = '';

  private timerSubscription!: Subscription;

  ngOnInit() {
    this.startTimer();
  }

  ngOnDestroy() {
    this.stopTimer();
  }

  private startTimer() {
    const interval = 1000;

    this.timerSubscription = timer(0, interval).subscribe(() => {
      var currentTime = new Date().getTime();
      var remainingTime = this.endTime ? this.endTime.getTime() - currentTime : 0;     

      if (remainingTime > 0) {
        this.displayTime = this.formatTime(remainingTime);
      } else if (remainingTime <= 0 && this.endTime != undefined) {
        this.displayTime = 'Czas minął';
        this.stopTimer();
      }
    });
  }

  private stopTimer() {
    if (this.timerSubscription) {
      this.timerSubscription.unsubscribe();
    }
  }

  private formatTime(milliseconds: number): string {
    const seconds = Math.floor((milliseconds / 1000) % 60);
    const minutes = Math.floor((milliseconds / (1000 * 60)) % 60);

    const displayMinutes = minutes.toString().padStart(2, '0');
    const displaySeconds = seconds.toString().padStart(2, '0');

    return `${displayMinutes}:${displaySeconds}`;
  }
}