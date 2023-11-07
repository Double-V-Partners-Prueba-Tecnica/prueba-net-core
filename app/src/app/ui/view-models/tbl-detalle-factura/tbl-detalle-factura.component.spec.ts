import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TblDetalleFacturaComponent } from './tbl-detalle-factura.component';

describe('TblDetalleFacturaComponent', () => {
  let component: TblDetalleFacturaComponent;
  let fixture: ComponentFixture<TblDetalleFacturaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TblDetalleFacturaComponent]
    });
    fixture = TestBed.createComponent(TblDetalleFacturaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
