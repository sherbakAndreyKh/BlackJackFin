import { async, TestBed } from '@angular/core/testing';
import { HistoryRoundDetailsModalComponent } from './history-round-details-modal.component';
describe('HistoryRoundDetailsModalComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [HistoryRoundDetailsModalComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(HistoryRoundDetailsModalComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=history-round-details-modal.component.spec.js.map