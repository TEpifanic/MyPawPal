// src/app/app.routes.ts
import { Routes } from '@angular/router';
/*import { DogsComponent } from './components/dogs/dogs.component';
import { DogDetailsComponent } from './components/dog-details/dog-details.component';
import { UserComponent } from './components/user/user.component';
import { UserDogsComponent } from './components/user-dogs/user-dogs.component';*/

export const routes: Routes = [
  /*{ path: 'dogs', component: DogsComponent },
  { path: 'dog/:id', component: DogDetailsComponent },
  { path: 'user/:id', component: UserComponent },
  { path: 'user-dogs/:id', component: UserDogsComponent },*/
  { path: '', redirectTo: '', pathMatch: 'full' }
];
