import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserDogsComponent } from './user-dogs.component';

describe('UserDogsComponent', () => {
  let component: UserDogsComponent;
  let fixture: ComponentFixture<UserDogsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserDogsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserDogsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
