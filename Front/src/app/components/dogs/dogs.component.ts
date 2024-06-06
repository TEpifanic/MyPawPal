import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from '../../services/api.services';
import { Dog } from '../../models/Dog'

@Component({
  selector: 'app-dogs',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dogs.component.html',
  styleUrls: ['./dogs.component.less']
})
export class DogsComponent implements OnInit {
  dogs: Dog[] = [];

  constructor(private apiService: ApiService) {}

  async ngOnInit() {
    try {
      this.dogs = await this.apiService.getDogs();
    } catch (error) {
      console.error('Error fetching dogs', error);
    }
  }
}
