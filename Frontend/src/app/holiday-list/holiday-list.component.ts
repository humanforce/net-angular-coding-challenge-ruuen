import { Component, Input, inject } from '@angular/core';
import { CardModule } from 'primeng/card';
import { Sprint } from '../types/sprint';
import { Holiday } from '../types/holiday';
import { HolidayService } from '../holiday.service';
import { DatePipe, NgFor } from '@angular/common';

@Component({
  selector: 'app-holiday-list',
  standalone: true,
  imports: [DatePipe, NgFor, CardModule],
  templateUrl: './holiday-list.component.html',
  styleUrl: './holiday-list.component.css',
})
export class HolidayListComponent {
  holidayService: HolidayService = inject(HolidayService);
  @Input() selectedSprint!: Sprint | null;
  holidayList: Holiday[] | null = null;

  ngOnChanges(): void {
    if (this.selectedSprint === null) {
      return;
    }

    this.holidayService
      .getAllInDateRange(
        this.selectedSprint.startDate,
        this.selectedSprint.endDate
      )
      .subscribe((holidays) => (this.holidayList = holidays));
  }
}
