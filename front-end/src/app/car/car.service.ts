import { Injectable, signal } from '@angular/core';
import { Car } from './car.model';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  private car1 = signal<Car>({ carNum: 1, color: 'blue', speed: 0 });
  private car2 = signal<Car>({ carNum: 2, color: 'yellow', speed: 0 });

  constructor() {
    this.simulateCarSpeeds();
  }

  private simulateCarSpeeds() {
    setInterval(() => {
      this.car1.update((car) => ({ ...car, speed: this.getRandomSpeed() }));
      this.car2.update((car) => ({ ...car, speed: this.getRandomSpeed() }));
    }, 1000);
  }

  private getRandomSpeed(): number {
    return Math.floor(Math.random() * 140);
  }

  getCar(carNumber: string) {
    switch (carNumber) {
      case '1':
        return this.car1.asReadonly();
      case '2':
        return this.car2.asReadonly();
      default:
        throw new Error('Invalid car number');
    }
  }
}
