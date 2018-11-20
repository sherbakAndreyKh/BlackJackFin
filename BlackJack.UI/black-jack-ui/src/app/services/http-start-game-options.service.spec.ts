import { TestBed } from '@angular/core/testing';
import { HttpStartGameOptionsService } from './http-start-game-options.service';

describe('HttpStartGameOptionsService', () => {
    beforeEach(() => TestBed.configureTestingModule({}));

    it('should be created', () => {
        const service: HttpStartGameOptionsService = TestBed.get(HttpStartGameOptionsService);
        expect(service).toBeTruthy();
    });
});
