import { TblCliente } from "../tbl-cliente/tbl-cliente";
import { TblDetalleFactura } from "../tbl-detalle-factura/tbl-detalle-factura";

export class TblFactura {
  id: number;
  fechaEmisionFactura: Date;
  idCliente: number;
  numeroDeFactura: number;
  numeroDeProductos: number;
  subTotalFactura: number;
  totalImpuestos: number;
  totalFactura: number;
  createdAt: Date;
  updatedAt: Date;
  deletedAt: Date | null;
  cliente: TblCliente;
  detalleFactura: TblDetalleFactura[];
}
