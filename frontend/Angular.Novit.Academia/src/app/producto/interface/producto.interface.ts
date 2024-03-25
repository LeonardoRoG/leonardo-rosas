import { IBarrio } from "./barrio.interface";


export interface IProducto{
    id: number;
    codigo: string;
    barrio: IBarrio;
    precio: number;
    urlImagen: string;
    estado: number;
}
