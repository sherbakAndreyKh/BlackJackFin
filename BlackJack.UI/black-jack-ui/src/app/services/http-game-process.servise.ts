import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestGetCardGameView } from '../models/requestModels/request-get-card-game-view';
import { ResponseGetCardGameView } from '../models/responseModels/response-get-card-game.model';
import { RequestGetFirstDealGameView } from '../models/requestModels/request-get-first-deal-game-view';
import { RequestBotLogicGameView } from '../models/requestModels/request-bot-logic-game-view';
import { RequestFindWinnerGameView } from '../models/requestModels/request-find-winner-game-view';

@Injectable()
export class HttpGameProcessService {
    urlGetCard = 'http://localhost:50219/Game/GetCard';
    urlGetFirstDeal = 'http://localhost:50219/Game/GetFirstDeal';
    urlGetBotLogic = 'http://localhost:50219/Game/BotAndDealerLogic';
    urlGetWinner = 'http://localhost:50219/Game/FindWinner';

    constructor(private http: HttpClient) { }

    HttpGetCard(model: RequestGetCardGameView) {
        return this.http.post(this.urlGetCard, model);
    }

    HttpGetFirstDeal(model: RequestGetFirstDealGameView) {
        return this.http.post(this.urlGetFirstDeal, model);
    }

    HttpGetBotAndDealerLogic(model: RequestBotLogicGameView) {
        return this.http.post(this.urlGetBotLogic, model);
    }

    HttpGetWinner(model: RequestFindWinnerGameView) {
        return this.http.post(this.urlGetWinner, model);
    }
}
