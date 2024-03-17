import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-sprint-control',
  standalone: true,
  imports: [ButtonModule],
  templateUrl: './sprint-control.component.html',
  styleUrl: './sprint-control.component.css',
})
export class SprintControlComponent {}
