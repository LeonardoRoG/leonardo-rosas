import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { ProductoService } from '../producto.service';
import { IProducto } from '../interface/producto.interface';
import { switchMap } from 'rxjs';

@Component({
  selector: 'app-producto-detalle',
  templateUrl: './producto-detalle.component.html',
  styleUrl: './producto-detalle.component.css'
})
export class ProductoDetalleComponent implements OnInit{
  
  private activatedRoute = inject(ActivatedRoute);
  private productoService = inject(ProductoService);

  productoId: number = 0;
  productoObtenido!: IProducto;
  
  ngOnInit(): void {
    this.activatedRoute.paramMap
      .subscribe(params => {
        this.productoId = parseInt(params.get('id')!);
        console.log('Id de ruta: ', this.productoId);
        this.obtenerProducto(this.productoId);
      })
  }

  obtenerProducto(id: number){
    this.productoService.getProductoPorId(id).subscribe({
      next: producto => {
        this.productoObtenido = producto;
        console.log(this.productoObtenido);
      },
      error: err => {
        console.error(err);
      }
    });
  }

  mostrarEstado(estado: number){
    if (estado == 0) {
      return 'Disponible';
    }
    else if (estado == 1){
      return 'Reservado';
    }
    else if (estado == 2){
      return 'Vendido';
    }
    return;
  }

}
