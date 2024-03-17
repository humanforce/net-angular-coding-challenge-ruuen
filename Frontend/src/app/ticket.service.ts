import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Ticket } from './types/ticket';

@Injectable({
  providedIn: 'root',
})
export class TicketService {
  private baseUrl = 'http://localhost:5195/api/ticket';
  private http = inject(HttpClient);

  getTicketsBySprint(sprintId: number): Observable<Ticket[]> {
    return this.http.get<Ticket[]>(`${this.baseUrl}/${sprintId}`);
  }

  constructor() {}
}
