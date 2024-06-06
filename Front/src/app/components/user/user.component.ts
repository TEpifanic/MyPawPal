import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ApiService } from '../../services/api.services';
import { User } from '../../models/User';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.less']
})

export class UserComponent implements OnInit {
  user: User | null = null;

  constructor(
    private route: ActivatedRoute,
    private apiService: ApiService
  ) {}

  async ngOnInit() {
    const id = "string";//this.route.snapshot.paramMap.get('id');
    if (id !== null) {
      try {
        this.user = await this.apiService.getUserById(id);
      } catch (error) {
        console.error('Error fetching user details', error);
      }
    } else {
      console.error('User ID is null');
    }
  }
}