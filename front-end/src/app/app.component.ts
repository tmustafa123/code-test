import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CarComponent } from './car/car.component';
import { Car } from './car/car.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'front-end';
}
