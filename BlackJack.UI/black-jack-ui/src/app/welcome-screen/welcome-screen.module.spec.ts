import { WelcomeScreenModule } from './welcome-screen.module';

describe('WelcomeScreenModule', () => {
    let welcomeScreenModule: WelcomeScreenModule;

    beforeEach(() => {
        welcomeScreenModule = new WelcomeScreenModule();
    });

    it('should create an instance', () => {
        expect(welcomeScreenModule).toBeTruthy();
    });
});
