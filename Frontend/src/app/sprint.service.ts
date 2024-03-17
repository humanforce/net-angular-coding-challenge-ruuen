import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sprint } from './types/sprint';

@Injectable({
  providedIn: 'root',
})
export class SprintService {
  private baseUrl = 'http://localhost:5195/api/sprint';
  private http = inject(HttpClient);

  getCurrentSprint(): Observable<Sprint> {
    return this.http.get<Sprint>(`${this.baseUrl}/currentSprint`);
  }

  constructor() {}
}
