import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [CommonModule, FormsModule , ],
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent {
  email: string = '';
  senha: string = '';
  nome: string = '';

  // Injete o AuthService no construtor
  constructor(private router: Router, private authService: AuthService) {}

  // Função de cadastro
  cadastro() {
    this.authService.cadastro(this.nome, this.email, this.senha).subscribe(
      (response) => {
        alert('Cadastro realizado com sucesso!');
        this.router.navigate(['/']);
      },
      (error) => {
        alert('Erro ao cadastrar');
      }
    );
  }
}
