import { HistoryPlayerListModule } from './history-player-list.module';

describe('HistoryPlayerListModule', () => {
  let historyPlayerListModule: HistoryPlayerListModule;

  beforeEach(() => {
    historyPlayerListModule = new HistoryPlayerListModule();
  });

  it('should create an instance', () => {
    expect(historyPlayerListModule).toBeTruthy();
  });
});
