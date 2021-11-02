import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateappealComponent } from './createappeal.component';

describe('CreateappealComponent', () => {
  let component: CreateappealComponent;
  let fixture: ComponentFixture<CreateappealComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateappealComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateappealComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
