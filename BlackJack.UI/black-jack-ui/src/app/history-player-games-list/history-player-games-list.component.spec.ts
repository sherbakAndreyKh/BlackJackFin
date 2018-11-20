import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HistoryPlayerGamesListComponent } from './history-player-games-list.component';

describe('HistoryPlayerGamesListComponent', () => {
    let component: HistoryPlayerGamesListComponent;
    let fixture: ComponentFixture<HistoryPlayerGamesListComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [HistoryPlayerGamesListComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(HistoryPlayerGamesListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
