import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { error } from 'console';
import { AuthService } from '../../Services/auth.service';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule,],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  // loginRequest: LoginRequest = {email:'', senha:''};
  
  email: string = "";
  senha: string = "";

  constructor(private router: Router , private authService: AuthService) { }

  // login() {
  //   this.authService.login(this.email, this.senha).subscribe({
  //     next: usuario => {
  //       alert('Login realizado com sucesso!');
  //     },
  //     error: err => {
  //       alert(err.error.mensagem || 'Erro ao fazer login.');
  //     }
  //   });
  // }

  login() {
    if (this.email === 'zago@email' && this.senha === '1234') {
      alert('Login realizado com sucesso!');
      this.router.navigate(['/home']); // redireciona para a rota "home"
    } else {
      alert('Email ou senha incorretos.');
    }
  }
}
