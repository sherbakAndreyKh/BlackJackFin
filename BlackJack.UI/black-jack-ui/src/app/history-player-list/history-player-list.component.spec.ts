import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoryPlayerListComponent } from './history-player-list.component';

describe('HistoryPlayerListComponent', () => {
  let component: HistoryPlayerListComponent;
  let fixture: ComponentFixture<HistoryPlayerListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HistoryPlayerListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoryPlayerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
