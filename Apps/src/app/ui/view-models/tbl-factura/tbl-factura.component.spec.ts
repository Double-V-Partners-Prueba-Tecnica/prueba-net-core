import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TblFacturaComponent } from './tbl-factura.component';

describe('TblFacturaComponent', () => {
  let component: TblFacturaComponent;
  let fixture: ComponentFixture<TblFacturaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TblFacturaComponent]
    });
    fixture = TestBed.createComponent(TblFacturaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
