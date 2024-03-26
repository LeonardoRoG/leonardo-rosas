import { IBarrio } from "./barrio.interface";


export interface IProducto{
    idProducto: number;
    codigo: string;
    barrio: IBarrio;
    precio: number;
    urlImagen: string;
    estado: number;
}
