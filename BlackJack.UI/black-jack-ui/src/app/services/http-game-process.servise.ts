import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestGetCardGameView } from 'src/app/models/requestModels/request-get-card-game-view';
import { RequestGetFirstDealGameView } from 'src/app/models/requestModels/request-get-first-deal-game-view';
import { RequestBotLogicGameView } from 'src/app/models/requestModels/request-bot-logic-game-view';
import { RequestFindWinnerGameView } from 'src/app/models/requestModels/request-find-winner-game-view';

@Injectable()
export class HttpGameProcessService {
    private urlGetCard = 'http://localhost:50219/Game/GetCard';
    private urlGetFirstDeal = 'http://localhost:50219/Game/GetFirstDeal';
    private urlGetBotLogic = 'http://localhost:50219/Game/BotAndDealerLogic';
    private urlGetWinner = 'http://localhost:50219/Game/FindWinner';

    constructor(private http: HttpClient) { }

    httpGetCard(model: RequestGetCardGameView) {
        return this.http.post(this.urlGetCard, model);
    }

    httpGetFirstDeal(model: RequestGetFirstDealGameView) {
        return this.http.post(this.urlGetFirstDeal, model);
    }

    httpGetBotAndDealerLogic(model: RequestBotLogicGameView) {
        return this.http.post(this.urlGetBotLogic, model);
    }

    httpGetWinner(model: RequestFindWinnerGameView) {
        return this.http.post(this.urlGetWinner, model);
    }
}
