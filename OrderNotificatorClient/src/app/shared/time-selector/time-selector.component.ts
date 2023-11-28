import { Component } from '@angular/core';
import { MatButtonToggleModule } from '@angular/material/button-toggle';

@Component({
  selector: 'time-selector',
  templateUrl: './time-selector.component.html',
  styleUrl: './time-selector.component.css',
  standalone: true,
  imports: [MatButtonToggleModule],
})
export class TimeSelectorComponent {

}
