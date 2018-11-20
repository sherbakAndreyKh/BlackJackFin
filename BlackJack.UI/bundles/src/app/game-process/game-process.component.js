var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
import { ResponseGameProcessGameView } from 'src/app/models/responseModels/response-game-process-game.model';
import { HttpGameProcessService } from 'src/app/services/http-game-process.servise';
import { RequestGetCardGameView } from 'src/app/models/requestModels/request-get-card-game-view';
import { RequestGetFirstDealGameView } from 'src/app/models/requestModels/request-get-first-deal-game-view';
import { RequestBotLogicGameView } from 'src/app/models/requestModels/request-bot-logic-game-view';
import { RequestFindWinnerGameView } from 'src/app/models/requestModels/request-find-winner-game-view';
var GameProcessComponent = /** @class */ (function () {
    function GameProcessComponent(service) {
        this.service = service;
        this.getCardRequest = new RequestGetCardGameView();
        this.getFirstDealRequest = new RequestGetFirstDealGameView();
        this.getBotAndDealerLogicRequest = new RequestBotLogicGameView();
        this.findWinner = new RequestFindWinnerGameView();
    }
    GameProcessComponent.prototype.ngOnInit = function () {
    };
    GameProcessComponent.prototype.addGetCardRequest = function () {
        this.getCardRequest.hand = this.model.player.playerRoundHand;
        this.getCardRequest.round = this.model.round;
    };
    GameProcessComponent.prototype.addFirstDealRequest = function () {
        this.getFirstDealRequest.hands = this.getAllHands();
        this.getFirstDealRequest.round = this.model.round;
    };
    GameProcessComponent.prototype.getCardClick = function () {
        var _this = this;
        this.addGetCardRequest();
        this.service.httpGetCard(this.getCardRequest).subscribe(function (data) { return _this.model.player.playerRoundHand = data.hand; });
    };
    GameProcessComponent.prototype.getFirstDealClick = function () {
        var _this = this;
        this.addFirstDealRequest();
        this.service.httpGetFirstDeal(this.getFirstDealRequest).subscribe(function (data) { return _this.addFirstDealResponse(data); });
    };
    GameProcessComponent.prototype.getBotAndDealerLogic = function (count) {
        var _this = this;
        this.service.httpGetBotAndDealerLogic(this.addBotAndDealerRequest(count)).subscribe(function (data) { return _this.getHand(count).playerRoundHand = data.hand; });
    };
    GameProcessComponent.prototype.addFindWinnerRequest = function () {
        this.findWinner.dealerHand = this.model.dealer.playerRoundHand;
        this.findWinner.playerHand = this.model.player.playerRoundHand;
        return this.findWinner;
    };
    GameProcessComponent.prototype.getWinner = function () {
        var _this = this;
        this.useLogicOnBotAndDealer();
        this.service.httpGetWinner(this.addFindWinnerRequest()).subscribe(function (data) { return _this.model.round = data.round; });
    };
    GameProcessComponent.prototype.getHand = function (count) {
        if (count < this.model.bots.length) {
            return this.model.bots[count];
        }
        if (count == this.model.bots.length) {
            return this.model.dealer;
        }
    };
    GameProcessComponent.prototype.useLogicOnBotAndDealer = function () {
        for (var i = 0; i <= this.model.bots.length; i++) {
            this.getBotAndDealerLogic(i);
        }
    };
    GameProcessComponent.prototype.addBotAndDealerRequest = function (count) {
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
    };
    GameProcessComponent.prototype.addFirstDealResponse = function (data) {
        debugger;
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
    };
    GameProcessComponent.prototype.getAllHands = function () {
        var Hands = new Array();
        Hands.push(this.model.dealer.playerRoundHand);
        Hands.push(this.model.player.playerRoundHand);
        for (var i = 0; i < this.model.bots.length; i++) {
            Hands.push(this.model.bots[i].playerRoundHand);
        }
        return Hands;
    };
    __decorate([
        Input(),
        __metadata("design:type", ResponseGameProcessGameView)
    ], GameProcessComponent.prototype, "model", void 0);
    GameProcessComponent = __decorate([
        Component({
            selector: 'app-game-process',
            templateUrl: './game-process.component.html',
            styleUrls: ['./game-process.component.css']
        }),
        __metadata("design:paramtypes", [HttpGameProcessService])
    ], GameProcessComponent);
    return GameProcessComponent;
}());
export { GameProcessComponent };
//# sourceMappingURL=game-process.component.js.map