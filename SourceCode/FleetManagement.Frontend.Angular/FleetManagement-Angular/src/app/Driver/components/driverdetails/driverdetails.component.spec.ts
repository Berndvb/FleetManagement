import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Driverdetailscomponent } from './driverdetails.component';

describe('DriverdetailsComponent', () => {
  let component: Driverdetailscomponent;
  let fixture: ComponentFixture<Driverdetailscomponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Driverdetailscomponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Driverdetailscomponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
