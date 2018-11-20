var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var HttpGameProcessService = /** @class */ (function () {
    function HttpGameProcessService(http) {
        this.http = http;
        this.urlGetCard = '/Game/GetCard';
        this.urlGetFirstDeal = 'Game/GetFirstDeal';
        this.urlGetBotLogic = 'Game/BotAndDealerLogic';
        this.urlGetWinner = 'Game/FindWinner';
        this.urlGetNewRound = 'Game/NewRound';
    }
    HttpGameProcessService.prototype.httpGetCard = function (model) {
        return this.http.post(this.urlGetCard, model);
    };
    HttpGameProcessService.prototype.httpGetFirstDeal = function (model) {
        return this.http.post(this.urlGetFirstDeal, model);
    };
    HttpGameProcessService.prototype.httpGetBotAndDealerLogic = function (model) {
        return this.http.post(this.urlGetBotLogic, model);
    };
    HttpGameProcessService.prototype.httpGetWinner = function (model) {
        return this.http.post(this.urlGetWinner, model);
    };
    HttpGameProcessService.prototype.httpNewRound = function (model) {
        return this.http.post(this.urlGetNewRound, model);
    };
    HttpGameProcessService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], HttpGameProcessService);
    return HttpGameProcessService;
}());
export { HttpGameProcessService };
//# sourceMappingURL=http-game-process.servise.js.map