import { Component, inject } from '@angular/core';
import { ProductoService } from '../producto.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { IProducto } from '../interface/producto.interface';

@Component({
  selector: 'app-nuevo-producto',
  templateUrl: './nuevo-producto.component.html',
  styleUrl: './nuevo-producto.component.css'
})
export class NuevoProductoComponent {

  private productoService = inject(ProductoService);

  productoForm!: FormGroup;
  nuevoProducto!: IProducto;

  constructor(private fb: FormBuilder){
    this.productoForm = this.fb.group({
      codigo:['', Validators.required],
      barrio: this.fb.group({
        nombre: ['',Validators.required]
      }),
      precio:['', Validators.required],
      urlImagen:['', Validators.required],
      estado: 0,
    });
  }

  agregarProducto(){
    const newProducto = this.productoForm.value as IProducto;
    console.log(newProducto);

    this.productoService.addProducto(newProducto).subscribe(
      response => {
        console.log('Producto agregado: ', response);
      },
      error => {
        console.error('Error al cargar el producto', error);
      }
    );
  }

}
