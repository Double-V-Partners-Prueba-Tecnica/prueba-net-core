import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TblFactura } from 'src/app/domain/models/tbl-factura/tbl-factura';
import { TblFacturaUseCases } from 'src/app/domain/usecase/tbl-factura-use-cases';

@Component({
  providers: [],
  selector: 'app-tbl-factura',
  templateUrl: './tbl-factura.component.html',
  styleUrls: ['./tbl-factura.component.scss'],
})
export class TblFacturaComponent implements OnInit {
  constructor(private _tblFacturaUseCase: TblFacturaUseCases) {}
  response$: Observable<TblFactura[]>;
  datos: TblFactura[];
  isLoading = true;
  ngOnInit(): void {
    this.response$ = this._tblFacturaUseCase.getAllTblFacturas();
    this.response$.subscribe((data) => {
      this.datos = data;
      this.isLoading = false;
    });
  }
}
