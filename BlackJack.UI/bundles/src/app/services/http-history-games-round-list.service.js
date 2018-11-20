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
var HttpHistoryGamesRoundListService = /** @class */ (function () {
    function HttpHistoryGamesRoundListService(http) {
        this.http = http;
        this.urlGetRounds = "http://localhost:50219/history/getrounds/";
        this.urlGetRoundsDetail = "http://localhost:50219/history/GetRoundsDetail/";
    }
    HttpHistoryGamesRoundListService.prototype.HttpGetRoundsWithId = function (id) {
        return this.http.get(this.urlGetRounds + id);
    };
    HttpHistoryGamesRoundListService.prototype.HttpGetRoundsDetail = function (id) {
        return this.http.get(this.urlGetRoundsDetail + id);
    };
    HttpHistoryGamesRoundListService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], HttpHistoryGamesRoundListService);
    return HttpHistoryGamesRoundListService;
}());
export { HttpHistoryGamesRoundListService };
//# sourceMappingURL=http-history-games-round-list.service.js.map