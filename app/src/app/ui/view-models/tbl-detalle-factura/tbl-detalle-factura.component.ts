import { Component, OnInit } from '@angular/core';
import { TblDetalleFacturaUseCases } from 'src/app/domain/usecase/tbl-detalle-factura-use-cases';

@Component({
  providers: [],
  selector: 'app-tbl-detalle-factura',
  templateUrl: './tbl-detalle-factura.component.html',
  styleUrls: ['./tbl-detalle-factura.component.scss'],
})
export class TblDetalleFacturaComponent implements OnInit {
  constructor(private _tblDetalleFacturaUseCase: TblDetalleFacturaUseCases) {}
  response$;
  datos;
  isLoading = true;
  ngOnInit(): void {
    this.response$ = this._tblDetalleFacturaUseCase.getAllTblDetalleFacturas();
    this.response$.subscribe((data) => {
      this.datos = data;
      this.isLoading = false;
    });
  }
}
