import { Component, OnInit, inject } from '@angular/core';
import { IReservaList } from '../interface/reserva.interface';
import { ReservaService } from '../reserva.service';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-reserva-list',
  templateUrl: './reserva-list.component.html',
  styleUrl: './reserva-list.component.css'
})
export class ReservaListComponent implements OnInit{
  title = 'Reservas';
  private reservaService = inject(ReservaService);
  private authService = inject(AuthService);
  
  
  panelOpenState = false;
  currentUser = this.authService.currentUser();
  totalReservas = 0;
  reservasIngresadas = 0;
  reservasAprobadas = 0;
  reservasCanceladas = 0;
  reservasRechazadas = 0;
  
  reservasList: IReservaList[] = [];
  
  ngOnInit(): void {
    this.obtenerReservas();
  }
  
  displayedColumns: string[] = ['idReserva', 'usuario', 'cliente', 'producto', 'estadoReserva'];
  
  obtenerReservas(){
    this.totalReservas = this.reservasAprobadas = this.reservasCanceladas = this.reservasRechazadas = this.reservasIngresadas = 0;
    this.reservaService.getReservas().subscribe({
      next: (reservas) => {
        this.reservasList = reservas;
        this.reservasList.reverse();
        this.reservasList.forEach(element => {
          if (element.usuario.username == this.currentUser?.name || this.currentUser?.role === 'comercial'){
            this.totalReservas++;
            switch (element.estadoReserva){
              case (0):{
                this.reservasIngresadas++;
                break
              }
              case (1):{
                this.reservasCanceladas++;
                break;
              }
              case (2):{
                this.reservasAprobadas++;
                break;
              }
              case (3): {
                this.reservasRechazadas++;
                break;
              }
              default:{
                break
              }
            }
          }
        });
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  mostrarEstado(estado: number){
    if (estado == 0) {
      return 'Ingresada';
    }
    else if (estado == 1){
      return 'Cancelada';
    }
    else if (estado == 2){
      return 'Aprobada';
    }
    else if (estado == 3){
      return 'Rechazada';
    }
    return;
  }
  
  cancelarReserva(idReserva: number){
    this.reservaService.cancelReserva(idReserva).subscribe({
      next: (res) => {
        console.log(res);
        
      },
      error: (err) => {
        console.log(err);
        
      },
      complete: () => {
        alert('Reserva cancelada.');
        this.obtenerReservas();
      }
    })
  };

  aprobarReserva(idReserva: number){
    this.reservaService.approveReserva(idReserva).subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (err) => {
        console.log(err);
        
      },
      complete: () => {
        alert('Reserva aprobada.')
        this.obtenerReservas();
      }
    })
  };

  rechazarReserva(idReserva: number){
    this.reservaService.rejectReserva(idReserva).subscribe({
      next: (res) => {
        console.log(res);
        
      },
      error: (err) => {
        console.error(err);
        
      },
      complete: () => {
        alert('Reserva rechazada.');
        this.obtenerReservas();
      }
    })
  }

}
