import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestGetCardGameView } from '../models/requestModels/request-get-card-game-view';

@Injectable()
export class HttpGameProcessService{
    
    urlGetCard = 'http://localhost:50219/Game/GetCard';

    constructor(private http: HttpClient){}

    HttpGetCard(model: RequestGetCardGameView){
        return this.http.post(this.urlGetCard, model);
    }
}