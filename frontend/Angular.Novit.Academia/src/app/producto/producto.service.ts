import { Injectable, inject } from '@angular/core';
import { IProducto } from './interface/producto.interface';
import { Observable, max } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from '../auth/auth.service';
import { enviroment } from '../enviroments/enviroments';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  private http = inject(HttpClient);
  private authService = inject(AuthService);
  private readonly url = enviroment.apiUrl;

  constructor(){}

  getProductos(): Observable<any>{
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.get<any>(`${this.url}/producto`, {headers});
  }

  title: string = 'Sección productos'

  getProductoPorId(id: number): Observable<any>{
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    });
    return this.http.get<any>(`${this.url}/producto/${id}`, {headers});
  } 

  addProducto(producto: IProducto): Observable<any> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.authService.getToken()}`
    })
    return this.http.post<any>(`${this.url}/producto`, producto, {headers})
  }

}
