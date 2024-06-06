import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ApiService } from '../../services/api.services';
import { Dog } from '../../models/Dog';

@Component({
  selector: 'app-user-dogs',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './user-dogs.component.html',
  styleUrls: ['./user-dogs.component.less'],
})

export class UserDogsComponent implements OnInit {
  userDogs: Dog[] = [];

  constructor(
    private route: ActivatedRoute,
    private apiService: ApiService
  ) {}

  async ngOnInit() {
    const id = "string";//this.route.snapshot.paramMap.get('id');
    if (id !== null) {
      try {
        this.userDogs = await this.apiService.getUserDogs(id);
        console.log(this.userDogs);
      } catch (error) {
        console.error('Error fetching user dogs', error);
      }
    } else {
      console.error('User ID is null');
    }
  }
}