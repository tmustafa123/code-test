import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarIconComponent } from './car-icon.component';

describe('CarIconComponent', () => {
  let component: CarIconComponent;
  let fixture: ComponentFixture<CarIconComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarIconComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
