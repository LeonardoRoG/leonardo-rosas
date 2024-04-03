import { Injectable, inject } from '@angular/core';
import { IReserva } from './interface/reserva.interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from '../auth/auth.service';
import { enviroment } from '../enviroments/enviroments';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {

  title = 'Sección Reservas'

  private http = inject(HttpClient);
  private authService = inject(AuthService);
  private readonly url = enviroment.apiUrl;

  constructor(){}

  getReservas(): Observable<any>{
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.get<any>(`${this.url}/reserva`, {headers});
  }

  getReservaPorId(id: number): Observable<any>{
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.get<any>(`${this.url}/reserva/${id}`, {headers});
  }

  addReserva(idProducto: number ,reserva: IReserva): Observable<any>{
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.post<any>(`${this.url}/reserva/${idProducto}`, reserva, {headers});
  }

  cancelReserva(idReserva: number): Observable<any>{
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.put<any>(`${this.url}/reserva/${idReserva}/cancelar`, '', {headers});
  }

  approveReserva(idReserva: number): Observable<any>{
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.put<any>(`${this.url}/reserva/${idReserva}/aprobar`, '', {headers});
  }

  rejectReserva(idReserva: number): Observable<any>{
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.put<any>(`${this.url}/reserva/${idReserva}/rechazar`, '', {headers});
  }

}
