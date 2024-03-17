import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SprintControlComponent } from './sprint-control/sprint-control.component';
import { SprintStatisticsComponent } from './sprint-statistics/sprint-statistics.component';
import { SprintTicketsComponent } from './sprint-tickets/sprint-tickets.component';
import { HolidayListComponent } from './holiday-list/holiday-list.component';
import { UserListComponent } from './user-list/user-list.component';
import { SprintService } from './sprint.service';
import { Sprint } from './types/sprint';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    SprintControlComponent,
    SprintStatisticsComponent,
    SprintTicketsComponent,
    HolidayListComponent,
    UserListComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  sprintService: SprintService = inject(SprintService);
  selectedSprint: Sprint | null = null;

  ngOnInit() {
    this.sprintService
      .getCurrentSprint()
      .subscribe((sprint) => (this.selectedSprint = sprint));
  }

  changeSprint = (startDate: string, endDate: string): void => {
    this.sprintService
      .getSprintByDate(startDate, endDate)
      .subscribe((sprint) => (this.selectedSprint = sprint));
  };
}
