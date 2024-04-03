import { Component, OnInit, inject } from '@angular/core';
import { IProducto } from '../interface/producto.interface';
import { ProductoService } from '../producto.service';

@Component({
  selector: 'app-producto-list',
  templateUrl: './producto-list.component.html',
  styleUrl: './producto-list.component.css'
})
export class ProductoListComponent implements OnInit{

  title: string = 'Productos'
  private productoService = inject(ProductoService);
  
  productosList: IProducto[] = [];
  
  cargarLista(){
    this.productoService.getProductos().subscribe({
      next: (productos) => {
        this.productosList = productos;
      },
      error: err => {
        console.log(err);
      }
    });
  }

  ngOnInit(): void {
    this.cargarLista();
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
        this.cargarLista();
      }
    });
  }

}
