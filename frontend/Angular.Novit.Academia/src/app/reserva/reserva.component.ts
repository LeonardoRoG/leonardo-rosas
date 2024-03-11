import { Component, inject } from '@angular/core';
import { IReserva } from './interface/reserva.interface';
import { ReservaService } from './reserva.service';

@Component({
  selector: 'app-reserva',
  templateUrl: './reserva.component.html',
  styleUrl: './reserva.component.css'
})
export class ReservaComponent {

  

  reservasList: IReserva[] = [];
  reservasService: ReservaService = inject(ReservaService);

  title = this.reservasService.title;
  
  constructor(){
    this.reservasList = this.reservasService.obtenerProductos();
  }

}
