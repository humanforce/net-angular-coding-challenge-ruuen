import { Component } from '@angular/core';
import { CardModule } from 'primeng/card';

@Component({
  selector: 'app-sprint-statistics',
  standalone: true,
  imports: [CardModule],
  templateUrl: './sprint-statistics.component.html',
  styleUrl: './sprint-statistics.component.css',
})
export class SprintStatisticsComponent {}
