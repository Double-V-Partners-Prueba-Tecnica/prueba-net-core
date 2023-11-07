import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatTipoClienteComponent } from './cat-tipo-cliente.component';

describe('CatTipoClienteComponent', () => {
  let component: CatTipoClienteComponent;
  let fixture: ComponentFixture<CatTipoClienteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CatTipoClienteComponent]
    });
    fixture = TestBed.createComponent(CatTipoClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
