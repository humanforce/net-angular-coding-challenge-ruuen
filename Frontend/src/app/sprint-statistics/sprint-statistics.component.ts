import { Component, Input, inject } from '@angular/core';
import { CardModule } from 'primeng/card';
import { SprintService } from '../sprint.service';
import { Sprint } from '../types/sprint';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-sprint-statistics',
  standalone: true,
  imports: [DecimalPipe, CardModule],
  templateUrl: './sprint-statistics.component.html',
  styleUrl: './sprint-statistics.component.css',
})
export class SprintStatisticsComponent {
  sprintService: SprintService = inject(SprintService);

  @Input() selectedSprint!: Sprint | null;
  capacityCalc: number = 0;
  velocityCalc: number = 0;

  ngOnChanges(): void {
    if (this.selectedSprint === null) {
      return;
    }
    console.log('init init');
    this.sprintService
      .getSprintCapacity(this.selectedSprint.id)
      .subscribe((capacity) => (this.capacityCalc = capacity.capacityPercent));
    this.sprintService
      .getSprintVelocity(this.selectedSprint.id)
      .subscribe((velocity) => (this.velocityCalc = velocity.value));
  }
}
