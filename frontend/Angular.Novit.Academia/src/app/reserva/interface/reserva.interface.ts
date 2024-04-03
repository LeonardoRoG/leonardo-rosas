import { User, UserReserva } from "../../auth/interface/user.interface";
import { IProducto } from "../../producto/interface/producto.interface";
import { Cliente } from "./cliente.interface";

export interface IReserva{
    cliente: Cliente;
    estadoReserva: number;
    solicitarAprobacion: boolean;
    usuario: UserReserva;
}

export interface IReservaList{
    idReserva: number;
    cliente: Cliente;
    producto: IProducto;
    estadoReserva: number;
    solicitarAprobacion: boolean;
    usuario: UserReserva;
}