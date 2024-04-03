import { Component, OnInit, inject } from '@angular/core';
import { ChartConfiguration } from 'chart.js';
import { IReservaList } from '../interface/reserva.interface';
import { ReservaService } from '../reserva.service';
import { BaseChartDirective } from 'ng2-charts';

@Component({
  selector: 'app-charts',
  standalone: true,
  imports: [BaseChartDirective],
  templateUrl: './charts.component.html',
  styleUrl: './charts.component.css'
})
export class ChartsComponent implements OnInit {
  private reservaService = inject(ReservaService);
  title = 'Dashboard';
  
  reservasList: IReservaList[] = [];
  users: string[] = [];
  ventas: Record<string, number> = {}
  montoVentas: Record<string, number> = {}
  
  dataVentas: number[] = [];
  dataMonto: number[] = [];

  public barChartLegend = true;
  public pieChartLegend = true;
  public barChartPlugins = [];
  public pieChartPlugins = [];
  
  public barChartData: ChartConfiguration<'bar'>['data'] = {
    labels: this.users,
    datasets: [
      { data: this.dataVentas, label: 'Cantidad de reservas'}
    ]
  }
  public pieChartLabels = this.users;
  public pieChartDatasets = [ {
    data: this.dataMonto
  }]

  // Aparentemene los charts tienen un bug porque cuando el diseño responsivo está desactivado
  // los valores del grafico de barras no se muestran. Cuando está activado es demasiado grande y
  // se muestran sólo si el tamaño de la pantalla cambia
  public barChartOptions: ChartConfiguration<'bar'>['options'] = {
    responsive: true,
  };
  public pieChartOptions: ChartConfiguration<'pie'>['options'] = {
    responsive: true,
  };
  
  ngOnInit(): void {
    this.obtenerReservas();
  }

  obtenerReservas(){
    this.reservaService.getReservas().subscribe({
      next: (reservas) => {
        this.reservasList = reservas;
        for (const reserva of this.reservasList) {
          const { usuario, producto} = reserva;
          const precio = reserva.producto.precio;

          this.ventas[usuario.username] = (this.ventas[usuario.username] || 0) + 1;
          this.montoVentas[usuario.username] = (this.montoVentas[usuario.username] || 0) + precio;
          this.users = Object.keys(this.ventas);
          this.dataVentas = Object.values(this.ventas);
          this.dataMonto = Object.values(this.montoVentas);
          this.barChartData.labels = this.users;
          this.barChartData.datasets = [
            {data: this.dataVentas, label: 'Cantidad de reservas'}
          ];
          this.pieChartLabels = this.users;
          this.pieChartDatasets = [
            {data: this.dataMonto}
          ];
        }
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
}
