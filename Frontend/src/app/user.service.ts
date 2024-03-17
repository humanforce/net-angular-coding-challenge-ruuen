import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './types/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseUrl = 'http://localhost:5195/api/user';
  private http: HttpClient = inject(HttpClient);

  getAll(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl);
  }

  constructor() {}
}
