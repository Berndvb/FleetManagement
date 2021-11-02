import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatefuelcardinfoComponent } from './updatefuelcardinfo.component';

describe('UpdatefuelcardinfoComponent', () => {
  let component: UpdatefuelcardinfoComponent;
  let fixture: ComponentFixture<UpdatefuelcardinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdatefuelcardinfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatefuelcardinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
