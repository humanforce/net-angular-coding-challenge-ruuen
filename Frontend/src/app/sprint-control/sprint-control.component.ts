import { Component, Input, inject } from '@angular/core';
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
  @Input() selectedSprint!: Sprint | null;
  @Input() changeSprint!: (startDate: string, endDate: string) => void;

  viewNextSprint(): void {
    if (this.selectedSprint == null) {
      return;
    }

    const newStart = new Date(this.selectedSprint.startDate.split('T')[0]);
    const newEnd = new Date(this.selectedSprint.endDate.split('T')[0]);

    newStart.setDate(newStart.getUTCDate() + 14);
    newEnd.setDate(newEnd.getUTCDate() + 14);

    this.changeSprint(newStart.toISOString(), newEnd.toISOString());
  }

  viewPrevSprint(): void {
    if (this.selectedSprint == null) {
      return;
    }

    const newStart = new Date(this.selectedSprint.startDate.split('T')[0]);
    const newEnd = new Date(this.selectedSprint.endDate.split('T')[0]);

    newStart.setUTCDate(newStart.getUTCDate() - 14);
    newEnd.setUTCDate(newEnd.getUTCDate() - 14);

    this.changeSprint(newStart.toISOString(), newEnd.toISOString());
  }
}
