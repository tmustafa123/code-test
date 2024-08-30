import { Component, input } from '@angular/core';
import { Car } from '../car.model';

@Component({
  selector: 'app-car-icon',
  standalone: true,
  imports: [],
  templateUrl: './car-icon.component.html',
  styleUrl: './car-icon.component.scss',
})
export class CarIconComponent {
  car = input.required<Car>();
}
