import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatecontactinfoComponent } from './updatecontactinfo.component';

describe('UpdatecontactinfoComponent', () => {
  let component: UpdatecontactinfoComponent;
  let fixture: ComponentFixture<UpdatecontactinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdatecontactinfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatecontactinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
