export interface IProducto{
    id: number;
    codigo: string;
    barrio: string;
    precio: number;
    urlImagen: string;
    estado: EEstado;
}

export enum EEstado{
    Disponible = 'Disponible',
    Reservada = 'Reservada',
    Vendida = 'Vendida'
}