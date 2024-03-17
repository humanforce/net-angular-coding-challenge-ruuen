import { Component } from '@angular/core';
import { CardModule } from 'primeng/card';

@Component({
  selector: 'app-holiday-list',
  standalone: true,
  imports: [CardModule],
  templateUrl: './holiday-list.component.html',
  styleUrl: './holiday-list.component.css',
})
export class HolidayListComponent {}
