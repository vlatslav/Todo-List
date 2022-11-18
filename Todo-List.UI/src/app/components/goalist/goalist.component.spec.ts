import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoalistComponent } from './goalist.component';

describe('GoalistComponent', () => {
  let component: GoalistComponent;
  let fixture: ComponentFixture<GoalistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GoalistComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GoalistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
