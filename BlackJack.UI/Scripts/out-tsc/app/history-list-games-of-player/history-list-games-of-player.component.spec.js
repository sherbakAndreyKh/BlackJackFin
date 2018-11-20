import { async, TestBed } from '@angular/core/testing';
import { HistoryListGamesOfPlayerComponent } from './history-list-games-of-player.component';
describe('HistoryListGamesOfPlayerComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [HistoryListGamesOfPlayerComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(HistoryListGamesOfPlayerComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=history-list-games-of-player.component.spec.js.map