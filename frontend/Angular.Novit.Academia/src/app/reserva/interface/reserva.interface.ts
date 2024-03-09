export interface Reserva{
    id: number;
    cliente: string;
    estadoReserva: estadoReserva;
}

enum estadoReserva{
    Ingresada = 'Ingresada',
    Aprobada = 'Aprobada',
    Cancelada = 'Cancelada',
    Rechazada = 'Rechazada'
}