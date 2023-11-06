// gateway/tbl-factura-gateway.ts

import { Observable } from 'rxjs';
import { TblFactura } from '../tbl-factura';

export abstract class TblFacturaGateway {
  abstract getByID(id: number): Observable<TblFactura>;
  abstract getAll(): Observable<Array<TblFactura>>;
  abstract saveNew(factura: TblFactura): Observable<TblFactura>;
}
