import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestGameStartOptionsView } from 'src/app/models/request-game-start-options-game.model';

@Injectable()
export class HttpStartGameOptionsService {
    private urlGetStartOptions = 'http://localhost:50219/Game/GameStartoptions';
    private urlPostStartOptions = 'http://localhost:50219/Game/GameStartoptions'
    constructor(private http: HttpClient) { }

    HttpGetStartOptions() {
        return this.http.get(this.urlGetStartOptions);
    }

    HttpPostStartOptions(model: RequestGameStartOptionsView) {
        return this.http.post(this.urlPostStartOptions, model);
    }
}
