import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Holiday } from './types/holiday';

@Injectable({
  providedIn: 'root',
})
export class HolidayService {
  private baseUrl = 'http://localhost:5195/api/publicHoliday';
  private http: HttpClient = inject(HttpClient);

  getAllInDateRange(startDate: string, endDate: string): Observable<Holiday[]> {
    const params = new URLSearchParams([
      ['startDate', startDate],
      ['endDate', endDate],
    ]);

    return this.http.get<Holiday[]>(`${this.baseUrl}?${params.toString()}`);
  }
  constructor() {}
}
