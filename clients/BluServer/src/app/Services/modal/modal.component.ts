import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  private modalAbertoSource = new BehaviorSubject<boolean>(false);
  modalAberto$ = this.modalAbertoSource.asObservable();

  abrirModal() {
    this.modalAbertoSource.next(true);
  }

  fecharModal() {
    this.modalAbertoSource.next(false);
  }

  
}