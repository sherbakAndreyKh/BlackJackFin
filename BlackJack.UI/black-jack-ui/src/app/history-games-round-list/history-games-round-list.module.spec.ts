import { HistoryGamesRoundListModule } from './history-games-round-list.module';

describe('HistoryGamesRoundListModule', () => {
  let historyGamesRoundListModule: HistoryGamesRoundListModule;

  beforeEach(() => {
    historyGamesRoundListModule = new HistoryGamesRoundListModule();
  });

  it('should create an instance', () => {
    expect(historyGamesRoundListModule).toBeTruthy();
  });
});
