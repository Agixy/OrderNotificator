import { Component, Input } from '@angular/core';

@Component({
  selector: 'timer',
  templateUrl: './timer.component.html',
  styleUrl: './timer.component.css',
  standalone: true,
})
export class TimerComponent {
  @Input() time: number = 0;

}
