import { async, TestBed } from '@angular/core/testing';
import { HistoryPlayerGamesListComponent } from './history-player-games-list.component';
describe('HistoryPlayerGamesListComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [HistoryPlayerGamesListComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(HistoryPlayerGamesListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=history-player-games-list.component.spec.js.map