import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultPageHeadComponent } from './result-page-head.component';

describe('ResultPageHeadComponent', () => {
  let component: ResultPageHeadComponent;
  let fixture: ComponentFixture<ResultPageHeadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResultPageHeadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResultPageHeadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
