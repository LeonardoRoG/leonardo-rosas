import { Component, OnInit, inject } from '@angular/core';
import { ReservaService } from '../reserva.service';
import { FormBuilder, ReactiveFormsModule, FormGroup, Validators } from '@angular/forms';
import { IReserva } from '../interface/reserva.interface';
import { AuthService } from '../../auth/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-nueva-reserva',
  templateUrl: './nueva-reserva.component.html',
  styleUrl: './nueva-reserva.component.css'
})
export class NuevaReservaComponent implements OnInit {

  private reservaService = inject(ReservaService);
  private authService = inject(AuthService);
  private activatedRoute = inject(ActivatedRoute);
  private router = inject(Router);

  currentUser = this.authService.currentUser();
  productoId: number = 0;

  reservaForm!: FormGroup;
  nuevaReserva!: IReserva;

  constructor(private fb: FormBuilder){
    this.reservaForm = this.fb.group({
      cliente: this.fb.group({
        nombre: ['', Validators.required],
      }),
      estadoReserva: [1, Validators.required],
      solicitarAprobacion: false,
      usuario: this.fb.group({
        username: ['', Validators.required]
      })
    });
  }

  ngOnInit(): void {
    this.activatedRoute.paramMap
      .subscribe(params => {
        this.productoId = parseInt(params.get('id')!);
        console.log('Id de ruta: ', this.productoId);
      })
  }

  agregarReserva(){
    const newReserva = this.reservaForm.value as IReserva;
    newReserva.usuario.username = this.currentUser!.name;
    console.log(newReserva);
    
    this.reservaService.addReserva(this.productoId, newReserva).subscribe({
      next: (reservaCreada) => {
        this.nuevaReserva = reservaCreada;
        this.reservaForm.reset();
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
        alert('Error al cargar la reserva.');
      },
      complete: () => {
        alert('Reserva agregada');
        this.router.navigateByUrl('/producto/productos');
      }
    });
  }

}
