import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultPageLogoComponent } from './result-page-logo.component';

describe('ResultPageLogoComponent', () => {
  let component: ResultPageLogoComponent;
  let fixture: ComponentFixture<ResultPageLogoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResultPageLogoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResultPageLogoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
