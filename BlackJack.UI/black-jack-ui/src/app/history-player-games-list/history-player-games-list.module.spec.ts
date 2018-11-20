import { HistoryPlayerGamesListModule } from './history-player-games-list.module';

describe('HistoryPlayerGamesListModule', () => {
    let historyPlayerGamesListModule: HistoryPlayerGamesListModule;

    beforeEach(() => {
        historyPlayerGamesListModule = new HistoryPlayerGamesListModule();
    });

    it('should create an instance', () => {
        expect(historyPlayerGamesListModule).toBeTruthy();
    });
});
