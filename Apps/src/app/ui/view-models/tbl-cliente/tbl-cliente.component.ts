import { Component, OnInit } from '@angular/core';
import { TblClienteUseCases } from 'src/app/domain/usecase/tbl-cliente-use-cases';

@Component({
  providers: [],
  selector: 'app-tbl-cliente',
  templateUrl: './tbl-cliente.component.html',
  styleUrls: ['./tbl-cliente.component.scss'],
})
export class TblClienteComponent implements OnInit {
  constructor(private _tblClienteUseCase: TblClienteUseCases) {}
  response$;
  datos;
  isLoading = true;
  ngOnInit(): void {
    this.response$ = this._tblClienteUseCase.getAllTblClientes();
    this.response$.subscribe((data) => {
      this.datos = data;
      this.isLoading = false;
    });
  }
}
