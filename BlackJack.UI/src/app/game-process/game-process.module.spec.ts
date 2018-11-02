import { GameProcessModule } from './game-process.module';

describe('GameProcessModule', () => {
  let gameProcessModule: GameProcessModule;

  beforeEach(() => {
    gameProcessModule = new GameProcessModule();
  });

  it('should create an instance', () => {
    expect(gameProcessModule).toBeTruthy();
  });
});
