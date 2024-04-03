import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductoService } from '../producto.service';
import { IProducto } from '../interface/producto.interface';

@Component({
  selector: 'app-producto-detalle',
  templateUrl: './producto-detalle.component.html',
  styleUrl: './producto-detalle.component.css'
})
export class ProductoDetalleComponent{
  
  private activatedRoute = inject(ActivatedRoute);
  private productoService = inject(ProductoService);

  productoId: number = 0;
  productoObtenido!: IProducto;
  
  constructor(){
    this.productoId = this.activatedRoute.snapshot.params['id'];
    this.obtenerProducto(this.productoId);
  }

  obtenerProducto(id: number){
    this.productoService.getProductoPorId(id).subscribe({
      next: producto => {
        this.productoObtenido = producto;
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

  navegarAtras(): void{
    window.history.back();
  }

  eliminarProducto(id: number){
    this.productoService.deleteProducto(id).subscribe({
      next: response => {
        console.log('Producto eliminado: ', response);
      },
      error: err => {
        console.error(err);
      },
      complete: () => {
        alert('Producto eliminado.');
        this.navegarAtras();
      }
    });
  }

}
