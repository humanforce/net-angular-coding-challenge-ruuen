import { Component, inject } from '@angular/core';
import { CardModule } from 'primeng/card';
import { TagModule } from 'primeng/tag';
import { UserService } from '../user.service';
import { User } from '../types/user';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [NgFor, CardModule, TagModule],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css',
})
export class UserListComponent {
  userService: UserService = inject(UserService);
  userData: User[] = [];

  // won't have time to implement the availability flag so not using onChanges here yet
  ngOnInit(): void {
    this.userService.getAll().subscribe((users) => (this.userData = users));
  }
}
