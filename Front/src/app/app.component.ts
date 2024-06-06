import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DogsComponent } from './components/dogs/dogs.component';
import { DogDetailsComponent } from './components/dog-details/dog-details.component';
import { UserComponent } from './components/user/user.component';
import { UserDogsComponent } from './components/user-dogs/user-dogs.component';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less'],
  imports: [
    RouterModule,
    DogsComponent,
    DogDetailsComponent,
    UserComponent,
    UserDogsComponent
  ]
})
export class AppComponent { }
