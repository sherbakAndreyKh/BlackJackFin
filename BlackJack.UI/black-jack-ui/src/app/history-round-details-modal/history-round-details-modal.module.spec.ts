import { HistoryRoundDetailsModalModule } from './history-round-details-modal.module';

describe('HistoryRoundDetailsModalModule', () => {
    let historyRoundDetailsModalModule: HistoryRoundDetailsModalModule;

    beforeEach(() => {
        historyRoundDetailsModalModule = new HistoryRoundDetailsModalModule();
    });

    it('should create an instance', () => {
        expect(historyRoundDetailsModalModule).toBeTruthy();
    });
});
