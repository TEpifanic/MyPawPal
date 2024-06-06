import { Injectable } from '@angular/core';
import axios from 'axios';
import { Dog } from '../models/Dog';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'http://localhost:5240';

  async getDogs(): Promise<Dog[]> {
    const response = await axios.get(`${this.baseUrl}/dog`);
    const data = response.data;
    if (data.$values) {
      return data.$values;
    }
    return [];
  }

  async getDogById(id: number): Promise<Dog> {
    const response = await axios.get(`${this.baseUrl}/dog/${id}`);
    const data = response.data;
    if (data.$values) {
      return data.$values[0];
    }
    return data;
  }

  async getUserById(id: string): Promise<User> {
    const response = await axios.get(`${this.baseUrl}/User/${id}`);
    const data = response.data;
    if (data.value) {
      return data.value;
    }
    return data;
  }

  async getUserDogs(id: string): Promise<Dog[]> {
    const response = await axios.get(`${this.baseUrl}/User/UserDogs/${id}`);
    const data = response.data;
    if (data.$values) {
      return data.$values;
    }
    return [];
  }
}