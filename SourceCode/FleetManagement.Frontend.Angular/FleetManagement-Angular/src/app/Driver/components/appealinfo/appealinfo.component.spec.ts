import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppealinfoComponent } from './appealinfo.component';

describe('AppealinfoComponent', () => {
  let component: AppealinfoComponent;
  let fixture: ComponentFixture<AppealinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppealinfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppealinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
