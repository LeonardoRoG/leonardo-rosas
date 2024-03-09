export interface Producto{
    id: number;
    codigo: string;
    barrio: string;
    precio: number;
    urlImagen: string;
    estado: estado;
}

enum estado{
    Disponible = 'Disponible',
    Reservada = 'Reservada',
    Vendida = 'Vendida'
}