import { async, TestBed } from '@angular/core/testing';
import { HistoryGamesRoundListComponent } from './history-games-round-list.component';
describe('HistoryGamesRoundListComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [HistoryGamesRoundListComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(HistoryGamesRoundListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=history-games-round-list.component.spec.js.map