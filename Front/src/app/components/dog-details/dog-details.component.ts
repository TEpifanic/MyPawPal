import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ApiService } from '../../services/api.services';
import { Dog } from '../../models/Dog';

@Component({
  selector: 'app-dog-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dog-details.component.html',
  styleUrls: ['./dog-details.component.less'],
})

export class DogDetailsComponent implements OnInit {
  dog: Dog | null = null;

  constructor(
    private route: ActivatedRoute,
    private apiService: ApiService
  ) {}

  async ngOnInit() {
    const id = "1";//this.route.snapshot.paramMap.get('id');
    if (id !== null) {
      try {
        this.dog = await this.apiService.getDogById(+id);
      } catch (error) {
        console.error('Error fetching dog details', error);
      }
    } else {
      console.error('Dog ID is null');
    }
  }
}
