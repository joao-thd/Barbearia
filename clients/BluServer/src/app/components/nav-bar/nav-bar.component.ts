import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalService } from '../../Services/modal/modal.component';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {

  constructor(private modalService: ModalService) {}

  scrollTo(section: string) {
    const element = document.getElementById(section);
    if (element) {
      element.scrollIntoView({ behavior: 'smooth' });
    }
  }

  abrirAgendamento() {
    this.modalService.abrirModal();
  }
}


