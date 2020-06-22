import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreUnitComponent } from './store-unit.component';

describe('StoreUnitComponent', () => {
  let component: StoreUnitComponent;
  let fixture: ComponentFixture<StoreUnitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StoreUnitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StoreUnitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
