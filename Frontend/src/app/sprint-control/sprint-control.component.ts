import { Component, inject } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { SprintService } from '../sprint.service';
import { Sprint } from '../types/sprint';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-sprint-control',
  standalone: true,
  imports: [DatePipe, ButtonModule],
  templateUrl: './sprint-control.component.html',
  styleUrl: './sprint-control.component.css',
})
export class SprintControlComponent {
  selectedSprint: Sprint | null = null;
  sprintService: SprintService = inject(SprintService);

  ngOnInit(): void {
    this.sprintService
      .getCurrentSprint()
      .subscribe((sprint) => (this.selectedSprint = sprint));
  }
}
