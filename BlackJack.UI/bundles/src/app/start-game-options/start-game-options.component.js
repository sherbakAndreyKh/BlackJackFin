var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { HttpStartGameOptionsService } from '../services/http-start-game-options.service';
import { RequestGameStartOptionsView } from '../models/request-game-start-options-game.model';
import { HttpGameProcessService } from '../services/http-game-process.servise';
var StartGameOptionsComponent = /** @class */ (function () {
    function StartGameOptionsComponent(service) {
        this.service = service;
        this.botsAmount = [0, 1, 2, 3, 4, 5];
        this.opened = true;
        this.reqModel = new RequestGameStartOptionsView();
    }
    StartGameOptionsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.service.HttpGet().subscribe(function (data) {
            _this.listPlayersName = _this.getNames(data);
        });
    };
    StartGameOptionsComponent.prototype.getNames = function (test) {
        var result = new Array();
        for (var i = 0; i < test.players.length; i++) {
            result.push(test.players[i].playerName);
        }
        return result;
    };
    StartGameOptionsComponent.prototype.close = function () {
        this.opened = false;
    };
    StartGameOptionsComponent.prototype.open = function () {
        this.opened = true;
    };
    StartGameOptionsComponent.prototype.submit = function (playerName, botsAmount) {
        var _this = this;
        this.reqModel.playerName = playerName;
        this.reqModel.botsAmount = botsAmount;
        this.service.HttpPost(this.reqModel).subscribe(function (data) {
            _this.responseModel = data;
        });
        this.close();
    };
    StartGameOptionsComponent = __decorate([
        Component({
            selector: 'app-start-game-options',
            templateUrl: './start-game-options.component.html',
            styleUrls: ['./start-game-options.component.css'],
            providers: [HttpStartGameOptionsService, HttpGameProcessService]
        }),
        __metadata("design:paramtypes", [HttpStartGameOptionsService])
    ], StartGameOptionsComponent);
    return StartGameOptionsComponent;
}());
export { StartGameOptionsComponent };
//# sourceMappingURL=start-game-options.component.js.map