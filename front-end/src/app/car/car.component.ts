import { Component, inject, signal, computed } from '@angular/core';
import { CarService } from './car.service';
import { CarIconComponent } from './car-icon/car-icon.component';

@Component({
  selector: 'app-car',
  standalone: true,
  imports: [ CarIconComponent],
  templateUrl: './car.component.html',
  styleUrl: './car.component.scss',
})
export class CarComponent {
  selectedCar = signal<string>('1');
  private carService = inject(CarService);

  car = computed(() => this.carService.getCar(this.selectedCar())());

  isSpeedHighlighted = computed(() => this.car().speed > 100);

  onChangeCar(carNumber: string) {
    this.selectedCar.set(carNumber);
  }
}
