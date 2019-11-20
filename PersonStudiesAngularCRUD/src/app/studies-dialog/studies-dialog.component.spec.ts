import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudiesDialogComponent } from './studies-dialog.component';

describe('StudiesDialogComponent', () => {
  let component: StudiesDialogComponent;
  let fixture: ComponentFixture<StudiesDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudiesDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudiesDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
