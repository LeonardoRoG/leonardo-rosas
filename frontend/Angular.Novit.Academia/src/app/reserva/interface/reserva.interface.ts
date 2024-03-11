export interface IReserva{
    id: number;
    cliente: string;
    productoId: number;
    estadoReserva: EEstadoReserva;
}

export enum EEstadoReserva{
    Ingresada = 'Ingresada',
    Aprobada = 'Aprobada',
    Cancelada = 'Cancelada',
    Rechazada = 'Rechazada'
}