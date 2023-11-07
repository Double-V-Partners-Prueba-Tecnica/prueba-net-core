import { Component, OnInit } from '@angular/core';
import { CatProductoUseCases } from 'src/app/domain/usecase/cat-producto-use-cases';

@Component({
  providers: [],
  selector: 'app-cat-producto',
  templateUrl: './cat-producto.component.html',
  styleUrls: ['./cat-producto.component.scss'],
})
export class CatProductoComponent implements OnInit {
  constructor(private _catProductoUseCase: CatProductoUseCases) {}
  response$;
  datos;
  isLoading = true;
  ngOnInit(): void {
    this.response$ = this._catProductoUseCase.getAllCatProductos();
    this.response$.subscribe((data) => {
      this.datos = data;
      this.isLoading = false;
    });
  }
}
