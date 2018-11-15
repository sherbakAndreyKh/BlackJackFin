import { StartGameOptionsModule } from './start-game-options.module';

describe('StartGameOptionsModule', () => {
  let startGameOptionsModule: StartGameOptionsModule;

  beforeEach(() => {
    startGameOptionsModule = new StartGameOptionsModule();
  });

  it('should create an instance', () => {
    expect(startGameOptionsModule).toBeTruthy();
  });
});
