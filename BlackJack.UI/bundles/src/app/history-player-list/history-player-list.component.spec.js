import { async, TestBed } from '@angular/core/testing';
import { HistoryPlayerListComponent } from './history-player-list.component';
describe('HistoryPlayerListComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [HistoryPlayerListComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(HistoryPlayerListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=history-player-list.component.spec.js.map