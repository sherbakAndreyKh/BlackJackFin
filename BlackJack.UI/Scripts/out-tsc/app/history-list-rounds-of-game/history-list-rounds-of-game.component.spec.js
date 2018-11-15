import { async, TestBed } from '@angular/core/testing';
import { HistoryListRoundsOfGameComponent } from './history-list-rounds-of-game.component';
describe('HistoryListRoundsOfGameComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [HistoryListRoundsOfGameComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(HistoryListRoundsOfGameComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=history-list-rounds-of-game.component.spec.js.map