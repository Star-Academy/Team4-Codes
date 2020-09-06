import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomePageHeadComponent } from './home-page-head.component';

describe('HomePageHeadComponent', () => {
  let component: HomePageHeadComponent;
  let fixture: ComponentFixture<HomePageHeadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomePageHeadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomePageHeadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
