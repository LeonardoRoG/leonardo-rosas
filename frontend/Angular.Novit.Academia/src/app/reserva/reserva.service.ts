import { Injectable } from '@angular/core';
import { EEstadoReserva, IReserva } from './interface/reserva.interface';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {

  title = 'Sección Reservas'

  protected reservas: IReserva[] = [
    {
      id: 1,
      cliente: 'Juan Carlo',
      productoId: 1,
      estadoReserva: EEstadoReserva.Ingresada
    }
  ];

  obtenerProductos(): IReserva[]{
    return this.reservas;
  }

  obtenerProductoPorId(id: number): IReserva | undefined{
    return this.reservas.find((reserva) => reserva.id === id);
  } 

}
