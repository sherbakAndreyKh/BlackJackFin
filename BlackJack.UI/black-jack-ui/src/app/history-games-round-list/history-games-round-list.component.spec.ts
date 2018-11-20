import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoryGamesRoundListComponent } from 'src/app/history-games-round-list/history-games-round-list.component';

describe('HistoryGamesRoundListComponent', () => {
    let component: HistoryGamesRoundListComponent;
    let fixture: ComponentFixture<HistoryGamesRoundListComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [HistoryGamesRoundListComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(HistoryGamesRoundListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
