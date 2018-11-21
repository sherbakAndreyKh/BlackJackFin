import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestGameStartOptionsView } from 'src/app/models/requestModels/request-game-start-options-game.model';

@Injectable()
export class HttpStartGameOptionsService {
    private urlGetStartOptions = '/Game/GameStartoptions';
    private urlPostStartOptions = '/Game/GameStartoptions'
    constructor(private http: HttpClient) { }

    HttpGetStartOptions() {
        return this.http.get(this.urlGetStartOptions);
    }

    HttpPostStartOptions(model: RequestGameStartOptionsView) {
        return this.http.post(this.urlPostStartOptions, model);
    }
}
