import { CommonModule } from '@angular/common';
import { Component, OnInit, OnDestroy, ChangeDetectorRef, NgZone } from '@angular/core';

@Component({
  selector: 'app-carrossel',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './carrossel.component.html',
  styleUrls: ['./carrossel.component.css']
})
export class CarrosselComponent implements OnInit, OnDestroy {
    imagens = [ 
      {
        src: 'assets/images/logo.png',
        titulo: 'Baixe Nosso Aplicativo',
        descricao: 'Agende seu horário de forma rápida e prática. Escolha o profissional de sua preferência, verifique valores e serviços, localização e muito mais.'
      },
      {
        src: 'assets/images/laelebarber.png',
        titulo: 'Experiência Premium',
        descricao: 'Tenha acesso aos melhores serviços com um clique.'
      },
      {
        src: 'assets/images/amorlindo.png',
        titulo: 'O lugar para grandes homens',
        descricao: 'Na Passione Barber oferecemos mais que cabelo, barba e bigode. Aqui você encontra e faz amigos enquanto relaxa e recebe um atendimento personalizado com profissionais altamente qualificados.'
      }
    ];
  
    indiceAtual = 0;
    intervaloId: any;

  constructor(private zone: NgZone, private cdr: ChangeDetectorRef) {}

  ngOnInit() {
    this.zone.runOutsideAngular(() => {
      this.intervaloId = setInterval(() => {
        this.zone.run(() => {
          this.proximo();
        });
      }, 4000);
    });
  }

  ngOnDestroy() {
    if (this.intervaloId) {
      clearInterval(this.intervaloId);
    }
  }
  
    proximo() {
      this.indiceAtual = (this.indiceAtual + 1) % this.imagens.length;
    }
  
    anterior() {
      this.indiceAtual = (this.indiceAtual - 1 + this.imagens.length) % this.imagens.length;
    }

  }
  