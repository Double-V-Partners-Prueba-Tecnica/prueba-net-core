import { Component, OnInit } from '@angular/core';
import { CatTipoClienteUseCases } from 'src/app/domain/usecase/cat-tipo-cliente-use-cases';

@Component({
  providers: [],
  selector: 'app-cat-tipo-cliente',
  templateUrl: './cat-tipo-cliente.component.html',
  styleUrls: ['./cat-tipo-cliente.component.scss'],
})
export class CatTipoClienteComponent implements OnInit {
  constructor(private _catTipoClienteUseCase: CatTipoClienteUseCases) {}
  response$;
  datos;
  isLoading = true;
  ngOnInit(): void {
    this.response$ = this._catTipoClienteUseCase.getAllCatTiposClientes();
    this.response$.subscribe((data) => {
      this.datos = data;
      this.isLoading = false;
    });
  }
}
