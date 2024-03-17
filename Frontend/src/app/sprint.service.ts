import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sprint } from './types/sprint';
import { SprintCapacity } from './types/sprint-capacity';
import { SprintVelocity } from './types/sprint-velocity';

@Injectable({
  providedIn: 'root',
})
export class SprintService {
  private baseUrl = 'http://localhost:5195/api/sprint';
  private http = inject(HttpClient);

  getCurrentSprint(): Observable<Sprint> {
    return this.http.get<Sprint>(`${this.baseUrl}/currentSprint`);
  }

  getSprintCapacity(sprintId: number): Observable<SprintCapacity> {
    return this.http.get<SprintCapacity>(
      `${this.baseUrl}/${sprintId}/capacity`
    );
  }

  getSprintVelocity(sprintId: number): Observable<SprintVelocity> {
    return this.http.get<SprintVelocity>(
      `${this.baseUrl}/${sprintId}/velocity`
    );
  }

  constructor() {}
}
