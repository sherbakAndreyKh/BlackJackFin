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
import { ResponseGameProcessGameView } from '../models/responseModels/response-game-process-game.model';
import { HttpGameProcessService } from '../services/http-game-process.servise';
import { RequestGetCardGameView } from '../models/requestModels/request-get-card-game-view';
import { RequestGetFirstDealGameView } from '../models/requestModels/request-get-first-deal-game-view';
import { RequestBotLogicGameView } from '../models/requestModels/request-bot-logic-game-view';
import { RequestFindWinnerGameView } from '../models/requestModels/request-find-winner-game-view';
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
        this.getCardRequest.Hand = this.model.Player.PlayerRoundHand;
        this.getCardRequest.Round = this.model.Round;
    };
    GameProcessComponent.prototype.addFirstDealRequest = function () {
        this.getFirstDealRequest.Hands = this.getAllHands();
        this.getFirstDealRequest.Round = this.model.Round;
    };
    GameProcessComponent.prototype.getCardClick = function () {
        var _this = this;
        this.addGetCardRequest();
        this.service.HttpGetCard(this.getCardRequest).subscribe(function (data) { return _this.model.Player.PlayerRoundHand = data.Hand; });
    };
    GameProcessComponent.prototype.getFirstDealClick = function () {
        var _this = this;
        this.addFirstDealRequest();
        this.service.HttpGetFirstDeal(this.getFirstDealRequest).subscribe(function (data) { return _this.addFirstDealResponse(data); });
    };
    GameProcessComponent.prototype.getBotAndDealerLogic = function (count) {
        var _this = this;
        this.service.HttpGetBotAndDealerLogic(this.addBotAndDealerRequest(count)).subscribe(function (data) { return _this.getHand(count).PlayerRoundHand = data.Hand; });
    };
    GameProcessComponent.prototype.addFindWinnerRequest = function () {
        this.findWinner.DealerHand = this.model.Dealer.PlayerRoundHand;
        this.findWinner.PlayerHand = this.model.Player.PlayerRoundHand;
        return this.findWinner;
    };
    GameProcessComponent.prototype.getWinner = function () {
        var _this = this;
        debugger;
        this.UseLogicOnBotAndDealer();
        debugger;
        this.service.HttpGetWinner(this.addFindWinnerRequest()).subscribe(function (data) { return _this.model.Round = data.Round; });
    };
    GameProcessComponent.prototype.getHand = function (count) {
        if (count < this.model.Bots.length) {
            return this.model.Bots[count];
        }
        if (count == this.model.Bots.length) {
            return this.model.Dealer;
        }
    };
    GameProcessComponent.prototype.UseLogicOnBotAndDealer = function () {
        for (var i = 0; i <= this.model.Bots.length; i++) {
            this.getBotAndDealerLogic(i);
        }
    };
    GameProcessComponent.prototype.addBotAndDealerRequest = function (count) {
        var hand;
        if (count < this.model.Bots.length) {
            hand = this.model.Bots[count].PlayerRoundHand;
        }
        if (count == this.model.Bots.length) {
            hand = this.model.Dealer.PlayerRoundHand;
        }
        this.getBotAndDealerLogicRequest.Round = this.model.Round;
        this.getBotAndDealerLogicRequest.Hand = hand;
        return this.getBotAndDealerLogicRequest;
    };
    GameProcessComponent.prototype.addFirstDealResponse = function (data) {
        debugger;
        for (var i = 0; i < data.Hands.length; i++) {
            if (i == 0) {
                this.model.Player.PlayerRoundHand = data.Hands[i];
            }
            if (i == data.Hands.length - 1) {
                this.model.Dealer.PlayerRoundHand = data.Hands[i];
            }
            if (i != 0 && i != data.Hands.length) {
                this.model.Bots[i - 1].PlayerRoundHand = data.Hands[i];
            }
        }
    };
    GameProcessComponent.prototype.getAllHands = function () {
        var Hands = new Array();
        Hands.push(this.model.Dealer.PlayerRoundHand);
        Hands.push(this.model.Player.PlayerRoundHand);
        for (var i = 0; i < this.model.Bots.length; i++) {
            Hands.push(this.model.Bots[i].PlayerRoundHand);
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