import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { NavBarComponent } from "./components/nav-bar/nav-bar.component";
import { CarrosselComponent } from './components/carrossel/carrossel.component';
import { ModalService } from './Services/modal/modal.component';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, FormsModule ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Passione Barber';

  modalAberto = false;

  servicos = [
    { nome: 'Corte de cabelo', selecionado: false },
    { nome: 'Barba', selecionado: false },
    { nome: 'Máquina', selecionado: false },
    { nome: 'Acabamento', selecionado: false },
    { nome: 'Escova progressiva', selecionado: false },
    { nome: 'Depilação com cera', selecionado: false },

  ];

  dataSelecionada: string = '';
  horariosDisponiveis: string[] = [];
  horarioSelecionado: string | null = null;

  constructor(private modalService: ModalService) {
    this.modalService.modalAberto$.subscribe(aberto => {
      this.modalAberto = aberto;
    });

    this.gerarHorarios(); // Gera horários assim que o componente carregar
  }

  gerarHorarios() {
    const horarios: string[] = [];
    let hora = 8;
    let minuto = 0;

    while (hora < 18) {
      const horaFormatada = `${hora.toString().padStart(2, '0')}:${minuto.toString().padStart(2, '0')}`;
      horarios.push(horaFormatada);

      minuto += 30;
      if (minuto === 60) {
        minuto = 0;
        hora += 1;
      }
    }

    this.horariosDisponiveis = horarios;
  }

  selecionarHorario(horario: string) {
    this.horarioSelecionado = horario;
  }

  fecharModal() {
    this.resetarFormulario();        
    this.modalService.fecharModal(); 
  }
  resetarFormulario() {
    this.servicos.forEach(servico => servico.selecionado = false);
    this.dataSelecionada = '';
    this.horarioSelecionado = null;
  }

  enviarFormulario() {
    const servicosSelecionados = this.servicos.filter(s => s.selecionado).map(s => s.nome);

    console.log('Serviços:', servicosSelecionados);
    console.log('Data:', this.dataSelecionada);
    console.log('Horário:', this.horarioSelecionado);

    // Aqui você pode enviar para o backend, exibir mensagem, etc.
    alert('Agendamento realizado com sucesso!');

    this.fecharModal(); // Fecha o modal após enviar
  }
}
