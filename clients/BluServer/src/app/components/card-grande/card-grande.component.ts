import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card-grande',
  standalone: true,
  imports: [],
  templateUrl: './card-grande.component.html',
  styleUrl: './card-grande.component.css'
})
export class CardGrandeComponent {
@Input() title: string = '';
@Input() content: string = '';
}
