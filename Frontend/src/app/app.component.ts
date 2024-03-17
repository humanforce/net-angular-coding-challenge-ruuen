import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SprintControlComponent } from './sprint-control/sprint-control.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SprintControlComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Frontend';
}
