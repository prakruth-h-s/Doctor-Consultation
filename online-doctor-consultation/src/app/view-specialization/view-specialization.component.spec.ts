import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSpecializationComponent } from './view-specialization.component';

describe('ViewSpecializationComponent', () => {
  let component: ViewSpecializationComponent;
  let fixture: ComponentFixture<ViewSpecializationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewSpecializationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewSpecializationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
