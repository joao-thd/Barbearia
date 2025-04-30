import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { CadastroComponent } from './components/cadastro/cadastro.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'home', component : HomeComponent},
    { path: 'login', component: LoginComponent },
    {path: 'cadastro', component: CadastroComponent}
];

