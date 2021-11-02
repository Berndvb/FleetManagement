import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FuelcardinfoComponent } from './fuelcardinfo.component';

describe('FuelcardinfoComponent', () => {
  let component: FuelcardinfoComponent;
  let fixture: ComponentFixture<FuelcardinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FuelcardinfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FuelcardinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
