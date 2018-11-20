import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestGameStartOptionsView } from '../models/request-game-start-options-game.model';

@Injectable()
export class HttpStartGameOptionsService {
    urlGet = 'http://localhost:50219/Game/GameStartoptions';
    urlPost = 'http://localhost:50219/Game/GameStartoptions'
    constructor(private http: HttpClient) { }

    HttpGet() {
        return this.http.get(this.urlGet);
    }

    HttpPost(model: RequestGameStartOptionsView) {
        return this.http.post(this.urlPost, model);
    }
}
