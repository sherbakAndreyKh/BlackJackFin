import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoryRoundDetailsModalComponent } from 'src/app/history-round-details-modal/history-round-details-modal.component';

describe('HistoryRoundDetailsModalComponent', () => {
    let component: HistoryRoundDetailsModalComponent;
    let fixture: ComponentFixture<HistoryRoundDetailsModalComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [HistoryRoundDetailsModalComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(HistoryRoundDetailsModalComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
