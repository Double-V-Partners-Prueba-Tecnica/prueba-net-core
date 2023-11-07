import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TblClienteComponent } from './tbl-cliente.component';

describe('TblClienteComponent', () => {
  let component: TblClienteComponent;
  let fixture: ComponentFixture<TblClienteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TblClienteComponent]
    });
    fixture = TestBed.createComponent(TblClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
