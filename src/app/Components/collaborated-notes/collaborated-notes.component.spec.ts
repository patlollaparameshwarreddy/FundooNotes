import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CollaboratedNotesComponent } from './collaborated-notes.component';

describe('CollaboratedNotesComponent', () => {
  let component: CollaboratedNotesComponent;
  let fixture: ComponentFixture<CollaboratedNotesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CollaboratedNotesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CollaboratedNotesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
