import { Component, OnInit, Input } from '@angular/core';
import { ResponseGameProcessGameView } from 'src/app/models/responseModels/response-game-process-game.model';
import { HttpGameProcessService } from 'src/app/services/http-game-process.servise';
import { RequestGetCardGameView } from 'src/app/models/requestModels/request-get-card-game-view';
import { ResponseGetCardGameView } from 'src/app/models/responseModels/response-get-card-game.model';
import { RequestGetFirstDealGameView } from 'src/app/models/requestModels/request-get-first-deal-game-view';
import { ResponseGetFirstDealGameView } from 'src/app/models/responseModels/response-get-first-deal-game.model';
import { RequestBotLogicGameView } from 'src/app/models/requestModels/request-bot-logic-game-view';
import { ResponseBotLogicGameView } from 'src/app/models/responseModels/response-bot-logic-game.model';
import { RequestFindWinnerGameView } from 'src/app/models/requestModels/request-find-winner-game-view';
import { ResponseFindWinnerGameView } from 'src/app/models/responseModels/response-find-winner-game.model';
import { ResponseNewRoundGameView } from '../models/responseModels/response-new-round-game.model';


@Component({
    selector: 'app-game-process',
    templateUrl: './game-process.component.html',
    styleUrls: ['./game-process.component.css']
})

export class GameProcessComponent implements OnInit {
    @Input() model: ResponseGameProcessGameView;
    getCardRequest: RequestGetCardGameView = new RequestGetCardGameView();
    getFirstDealRequest: RequestGetFirstDealGameView = new RequestGetFirstDealGameView();
    getBotAndDealerLogicRequest: RequestBotLogicGameView = new RequestBotLogicGameView();
    findWinner: RequestFindWinnerGameView = new RequestFindWinnerGameView();

    constructor(private service: HttpGameProcessService) { }
    ngOnInit() {
    }

    addGetCardRequest(): void {
        this.getCardRequest.hand = this.model.player.playerRoundHand;
        this.getCardRequest.round = this.model.round;
    }

    addFirstDealRequest(): void {
        this.getFirstDealRequest.hands = this.getAllHands();
        this.getFirstDealRequest.round = this.model.round;
    }

    newRound(): void {
        this.service.httpNewRound(this.model).subscribe((data: ResponseNewRoundGameView) => this.model = data);
    }

    getCardClick(): void {
        this.addGetCardRequest();
        this.service.httpGetCard(this.getCardRequest).subscribe((data: ResponseGetCardGameView) => this.model.player.playerRoundHand = data.hand);
    }

    getFirstDealClick(): void {
        this.addFirstDealRequest();
        this.service.httpGetFirstDeal(this.getFirstDealRequest).subscribe((data: ResponseGetFirstDealGameView) => this.addFirstDealResponse(data));
    }

    getBotAndDealerLogic(count: number): void {
        this.service.httpGetBotAndDealerLogic(this.addBotAndDealerRequest(count)).subscribe((data: ResponseBotLogicGameView) => this.getHand(count).playerRoundHand = data.hand)
    }

    addFindWinnerRequest(): RequestFindWinnerGameView {
        this.findWinner.dealerHand = this.model.dealer.playerRoundHand;
        this.findWinner.playerHand = this.model.player.playerRoundHand;
        return this.findWinner;
    }

    getWinner(): void {
        this.useLogicOnBotAndDealer();
        this.service.httpGetWinner(this.addFindWinnerRequest()).subscribe((data: ResponseFindWinnerGameView) => this.model.round = data.round)
    }

    getHand(count) {
        if (count < this.model.bots.length) {
            return this.model.bots[count];
        }
        if (count == this.model.bots.length) {
            return this.model.dealer;
        }
    }

    useLogicOnBotAndDealer(): void {
        for (var i = 0; i <= this.model.bots.length; i++) {
            this.getBotAndDealerLogic(i);
        }
    }

    addBotAndDealerRequest(count: number) {
        var hand;
        if (count < this.model.bots.length) {
            hand = this.model.bots[count].playerRoundHand;
        }
        if (count == this.model.bots.length) {
            hand = this.model.dealer.playerRoundHand;
        }
        this.getBotAndDealerLogicRequest.round = this.model.round;
        this.getBotAndDealerLogicRequest.hand = hand;
        return this.getBotAndDealerLogicRequest;
    }

    addFirstDealResponse(data): void {
        for (var i = 0; i < data.hands.length; i++) {
            if (i == 0) {
                this.model.player.playerRoundHand = data.hands[i];
            }

            if (i == data.hands.length - 1) {
                this.model.dealer.playerRoundHand = data.hands[i];
            }

            if (i != 0 && i != data.hands.length - 1) {
                this.model.bots[i - 1].playerRoundHand = data.hands[i];
            }
        }
    }

    getAllHands() {
        var Hands = new Array();
        Hands.push(this.model.dealer.playerRoundHand);
        Hands.push(this.model.player.playerRoundHand);
        for (var i = 0; i < this.model.bots.length; i++) {
            Hands.push(this.model.bots[i].playerRoundHand);
        }
        return Hands
    }
}
