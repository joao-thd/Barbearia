import { Component } from '@angular/core';
import { NavBarComponent } from "../../components/nav-bar/nav-bar.component";
import { CardComponent } from "../../components/card/card.component";
import { CardGrandeComponent } from "../../components/card-grande/card-grande.component";
import { CardServicosComponent } from "../../components/card-servicos/card-servicos.component";
import { CarrosselComponent } from "../../components/carrossel/carrossel.component";
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ModalService } from '../../Services/modal/modal.component';



@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NavBarComponent, CardComponent, CardGrandeComponent, CardServicosComponent, CarrosselComponent, CommonModule, RouterOutlet],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  showCarrossel = true;
  showNavbar = true;
  modalAberto = false;

  
  constructor(
    private router: Router,
    private modalService: ModalService
  ) {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        if (event.url === '/login') {
          this.showCarrossel = false;
          this.showNavbar = false;
        } else {
          this.showCarrossel = true;
          this.showNavbar = true;
        }
      }
    });
  
    this.modalService.modalAberto$.subscribe(aberto => {
      this.modalAberto = aberto;
    });
  }

  fecharModal() {
    this.modalService.fecharModal();
  }


  cards = [
    {
      title: 'Corte',
      content: 'Corte na tesoura ou máquina',
      imageUrl: 'assets/images/fotoCorte2.png'
    },
    {
      title: 'Barba',
      content: 'Modelagem completa da barba',
      imageUrl: 'assets/images/fotoBarba.png'
    },
    {
      title: 'Máquina',
      content: 'Corte rápido só na máquina',
      imageUrl: 'assets/images/fotoMaquina.png'
    },
    {
      title: 'Escova progressiva',
      content: 'Alisamento com escova progressiva',
      imageUrl: 'assets/images/fotoProgressiva.png'
    },
    {
      title: 'Depilação com cera',
      content: 'Depilação facial com linha ou cera',
      imageUrl: 'assets/images/fotoDepilacao.png'
    },
    {
      title: 'Acabamentos',
      content: 'Detalhamento na régua ou navalha',
      imageUrl: 'assets/images/fotoAcabamento.png'
    }
  ];
}
