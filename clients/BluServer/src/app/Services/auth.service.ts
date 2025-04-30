import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class AuthService{
    private apiUrl = 'http://localhost:5129/api/Usuario' //Url do backend do projeto

    constructor(private http: HttpClient){}

    //Função login
    login(email: string, senha: string): Observable<any> {
        return this.http.post(`${this.apiUrl}/login`, { email, senha });
      }
      
    

    //Função cadastro
    cadastro(nome:string , email : string, senha: string): Observable<any>{
        return this.http.post(`${this.apiUrl}`, { nome, email, senha });
    }
}