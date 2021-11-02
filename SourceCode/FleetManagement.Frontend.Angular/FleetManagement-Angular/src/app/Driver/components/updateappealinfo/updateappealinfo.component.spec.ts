import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateappealinfoComponent } from './updateappealinfo.component';

describe('UpdateappealinfoComponent', () => {
  let component: UpdateappealinfoComponent;
  let fixture: ComponentFixture<UpdateappealinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateappealinfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateappealinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
