import { Component, OnInit, inject } from '@angular/core';
import { ProductoService } from '../producto.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IProducto } from '../interface/producto.interface';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-producto-edit',
  templateUrl: './producto-edit.component.html',
  styleUrl: './producto-edit.component.css',
})
export class ProductoEditComponent implements OnInit {
  private productoService = inject(ProductoService);
  private activatedRoute = inject(ActivatedRoute);
  private router = inject(Router);

  productoId = 0;
  productoAEditar!: IProducto;
  productoForm!: FormGroup;

  // Activar o desactivar el botón de cancelar reserva
  disabledButton = true;

  estadoProducto: string[] = ['disponible', 'reservado', 'vendido'];

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((params) => {
      this.productoId = parseInt(params.get('id')!);
      this.obtenerProducto(this.productoId);
    });
    if (this.productoAEditar.estado == 1) {
      this.disabledButton = false;
    } else {
      this.disabledButton = true;
    }
  }

  constructor(private fb: FormBuilder) {
    this.productoForm = this.fb.group({
      codigo: ['', Validators.required],
      barrio: this.fb.group({
        nombre: ['', Validators.required],
      }),
      precio: ['', Validators.required],
      urlImagen: ['', Validators.required],
      estado: ['', Validators.required],
    });
  }

  navegarAtras(): void{
    window.history.back();
  }

  obtenerProducto(id: number) {
    this.productoService.getProductoPorId(id).subscribe({
      next: (producto) => {
        this.productoAEditar = producto;
        this.productoForm = this.fb.group({
          codigo: [this.productoAEditar.codigo, Validators.required],
          barrio: this.fb.group({
            nombre: [this.productoAEditar.barrio.nombre, Validators.required],
          }),
          precio: [this.productoAEditar.precio, Validators.required],
          urlImagen: [this.productoAEditar.urlImagen, Validators.required],
          estado: [this.productoAEditar.estado, Validators.required],
        });
      },
      error: (err) => {
        console.error(err);
      },
    });
  }

  editarProducto() {
    const editProducto = this.productoForm.value as IProducto;
    editProducto.estado = this.productoAEditar.estado;

    this.productoService.editProducto(this.productoId, editProducto).subscribe({
      next: (productoEditado) => {
        this.productoAEditar = productoEditado;
        this.productoForm.reset();
      },
      error: (err) => {
        console.log(err);
      },
      complete: () => {
        alert('Producto editado');
        this.router.navigateByUrl('/producto/productos');
      },
    });
  }

  mostrarEstado(estado: number) {
    if (estado == 0) {
      return 'Disponible';
    } else if (estado == 1) {
      return 'Reservado';
    } else if (estado == 2) {
      return 'Vendido';
    }
    return;
  }
}
