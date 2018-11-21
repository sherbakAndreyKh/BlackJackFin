(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["default~game-process-game-process-module~start-game-options-start-game-options-module"],{

/***/ "./src/app/game-process/game-process.component.css":
/*!*********************************************************!*\
  !*** ./src/app/game-process/game-process.component.css ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".field {\r\n    margin-top: 150px;\r\n    width: 100%;\r\n    height: 70%;\r\n    min-height: 400px;\r\n    background-color: darkred;\r\n}\r\n.dealer{\r\n    position: absolute;\r\n    width: 100px;\r\n    padding: 5px;\r\n    top: 200px;\r\n    left:  47%;\r\n}\r\n.SelectAmountBots{\r\n    width: 100px;\r\n    height: 30px;\r\n    \r\n}\r\n.Score{\r\n    font-weight: bold;\r\n}\r\n.Hand{\r\n    font-weight: bold;\r\n}\r\n"

/***/ }),

/***/ "./src/app/game-process/game-process.component.html":
/*!**********************************************************!*\
  !*** ./src/app/game-process/game-process.component.html ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"text-center container \">\r\n\r\n    <h2>Player Name: {{model?.player.name}}</h2>\r\n\r\n    <h3>{{model?.round.winner}}</h3>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-6\">\r\n            <h3>Game Number: {{model?.game.gameNumber}}</h3>\r\n        </div>\r\n        <div class=\"col-md-6\">\r\n            <h3>Round Number: {{model?.round.roundNumber}}</h3>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"field text-center\">\r\n        <img src=\"/Content/Img/bj.jpg\" alt=\"Alternate Text\" />\r\n    </div>\r\n    \r\n\r\n    <div class=\"row\">\r\n    <div class=\"player col-md-2\">\r\n        <p><span *ngFor=\"let card of model?.player.playerRoundHand.hand\"><img src=\"{{card.imgPath}}\" alt=\"Alternate Text\"/>, </span> </p>\r\n        <p>{{model?.player.playerRoundHand.score}}</p>\r\n        <h4>{{model?.player.name}}</h4>\r\n    </div>\r\n    <hr>\r\n\r\n    <div *ngFor=\"let bot of model?.bots \" class=\"player col-md-2\">\r\n        <p><span *ngFor=\"let card of bot?.playerRoundHand.hand\"><img src=\"{{card.imgPath}}\" alt=\"Alternate Text\"/>,</span> </p>\r\n        <p>{{bot.playerRoundHand.score}}</p>\r\n        <h4>{{bot.name}}</h4>\r\n    </div>\r\n    <hr>\r\n</div>\r\n    <div class=\"dealer col-md-2\">\r\n        <h4>{{model?.dealer.name}}</h4>\r\n        <p>{{model?.dealer.playerRoundHand.score}}</p>\r\n        <p><span *ngFor=\"let card of model?.dealer.playerRoundHand.hand\"><img src=\"{{card.imgPath}}\" alt=\"Alternate Text\"/>,</span></p>\r\n    </div>\r\n\r\n    <div class=\"text-right\">\r\n        <button kendoButton (click)=\"getFirstDealClick()\">Start Game</button>\r\n        <button kendoButton (click)=\"getCardClick()\">Get Card</button>\r\n        <button kendoButton (click)=\"getWinner()\">Stop</button>\r\n        <button kendoButton (click)=\"newRound()\">End Round</button>\r\n    </div>\r\n\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/game-process/game-process.component.ts":
/*!********************************************************!*\
  !*** ./src/app/game-process/game-process.component.ts ***!
  \********************************************************/
/*! exports provided: GameProcessComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GameProcessComponent", function() { return GameProcessComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var src_app_models_responseModels_response_game_process_game_model__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/models/responseModels/response-game-process-game.model */ "./src/app/models/responseModels/response-game-process-game.model.ts");
/* harmony import */ var src_app_services_http_game_process_servise__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/services/http-game-process.servise */ "./src/app/services/http-game-process.servise.ts");
/* harmony import */ var src_app_models_requestModels_request_get_card_game_view__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/models/requestModels/request-get-card-game-view */ "./src/app/models/requestModels/request-get-card-game-view.ts");
/* harmony import */ var src_app_models_requestModels_request_get_first_deal_game_view__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/models/requestModels/request-get-first-deal-game-view */ "./src/app/models/requestModels/request-get-first-deal-game-view.ts");
/* harmony import */ var src_app_models_requestModels_request_bot_logic_game_view__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/models/requestModels/request-bot-logic-game-view */ "./src/app/models/requestModels/request-bot-logic-game-view.ts");
/* harmony import */ var src_app_models_requestModels_request_find_winner_game_view__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! src/app/models/requestModels/request-find-winner-game-view */ "./src/app/models/requestModels/request-find-winner-game-view.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var GameProcessComponent = /** @class */ (function () {
    function GameProcessComponent(service) {
        this.service = service;
        this.getCardRequest = new src_app_models_requestModels_request_get_card_game_view__WEBPACK_IMPORTED_MODULE_3__["RequestGetCardGameView"]();
        this.getFirstDealRequest = new src_app_models_requestModels_request_get_first_deal_game_view__WEBPACK_IMPORTED_MODULE_4__["RequestGetFirstDealGameView"]();
        this.getBotAndDealerLogicRequest = new src_app_models_requestModels_request_bot_logic_game_view__WEBPACK_IMPORTED_MODULE_5__["RequestBotLogicGameView"]();
        this.findWinner = new src_app_models_requestModels_request_find_winner_game_view__WEBPACK_IMPORTED_MODULE_6__["RequestFindWinnerGameView"]();
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
    GameProcessComponent.prototype.newRound = function () {
        var _this = this;
        this.service.httpNewRound(this.model).subscribe(function (data) { return _this.model = data; });
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
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", src_app_models_responseModels_response_game_process_game_model__WEBPACK_IMPORTED_MODULE_1__["ResponseGameProcessGameView"])
    ], GameProcessComponent.prototype, "model", void 0);
    GameProcessComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-game-process',
            template: __webpack_require__(/*! ./game-process.component.html */ "./src/app/game-process/game-process.component.html"),
            styles: [__webpack_require__(/*! ./game-process.component.css */ "./src/app/game-process/game-process.component.css")]
        }),
        __metadata("design:paramtypes", [src_app_services_http_game_process_servise__WEBPACK_IMPORTED_MODULE_2__["HttpGameProcessService"]])
    ], GameProcessComponent);
    return GameProcessComponent;
}());



/***/ }),

/***/ "./src/app/models/requestModels/request-bot-logic-game-view.ts":
/*!*********************************************************************!*\
  !*** ./src/app/models/requestModels/request-bot-logic-game-view.ts ***!
  \*********************************************************************/
/*! exports provided: RequestBotLogicGameView, PlayerRoundHandBotLogicGameViewItem, CardBotLogicGameViewItem, RoundRoundHandBotLogicGameViewItem */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RequestBotLogicGameView", function() { return RequestBotLogicGameView; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PlayerRoundHandBotLogicGameViewItem", function() { return PlayerRoundHandBotLogicGameViewItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CardBotLogicGameViewItem", function() { return CardBotLogicGameViewItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RoundRoundHandBotLogicGameViewItem", function() { return RoundRoundHandBotLogicGameViewItem; });
var RequestBotLogicGameView = /** @class */ (function () {
    function RequestBotLogicGameView() {
    }
    return RequestBotLogicGameView;
}());

var PlayerRoundHandBotLogicGameViewItem = /** @class */ (function () {
    function PlayerRoundHandBotLogicGameViewItem() {
    }
    return PlayerRoundHandBotLogicGameViewItem;
}());

var CardBotLogicGameViewItem = /** @class */ (function () {
    function CardBotLogicGameViewItem() {
    }
    return CardBotLogicGameViewItem;
}());

var RoundRoundHandBotLogicGameViewItem = /** @class */ (function () {
    function RoundRoundHandBotLogicGameViewItem() {
    }
    return RoundRoundHandBotLogicGameViewItem;
}());



/***/ }),

/***/ "./src/app/models/requestModels/request-find-winner-game-view.ts":
/*!***********************************************************************!*\
  !*** ./src/app/models/requestModels/request-find-winner-game-view.ts ***!
  \***********************************************************************/
/*! exports provided: RequestFindWinnerGameView, PlayerRoundHandFindWinnerGameViewItem */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RequestFindWinnerGameView", function() { return RequestFindWinnerGameView; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PlayerRoundHandFindWinnerGameViewItem", function() { return PlayerRoundHandFindWinnerGameViewItem; });
var RequestFindWinnerGameView = /** @class */ (function () {
    function RequestFindWinnerGameView() {
    }
    return RequestFindWinnerGameView;
}());

var PlayerRoundHandFindWinnerGameViewItem = /** @class */ (function () {
    function PlayerRoundHandFindWinnerGameViewItem() {
    }
    return PlayerRoundHandFindWinnerGameViewItem;
}());



/***/ }),

/***/ "./src/app/models/requestModels/request-get-card-game-view.ts":
/*!********************************************************************!*\
  !*** ./src/app/models/requestModels/request-get-card-game-view.ts ***!
  \********************************************************************/
/*! exports provided: RequestGetCardGameView, PlayerRoundHandGetCardGameViewItem, CardGetCardGameViewItem, RoundRoundHandGetCardGameViewItem */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RequestGetCardGameView", function() { return RequestGetCardGameView; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PlayerRoundHandGetCardGameViewItem", function() { return PlayerRoundHandGetCardGameViewItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CardGetCardGameViewItem", function() { return CardGetCardGameViewItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RoundRoundHandGetCardGameViewItem", function() { return RoundRoundHandGetCardGameViewItem; });
var RequestGetCardGameView = /** @class */ (function () {
    function RequestGetCardGameView() {
    }
    return RequestGetCardGameView;
}());

var PlayerRoundHandGetCardGameViewItem = /** @class */ (function () {
    function PlayerRoundHandGetCardGameViewItem() {
    }
    return PlayerRoundHandGetCardGameViewItem;
}());

var CardGetCardGameViewItem = /** @class */ (function () {
    function CardGetCardGameViewItem() {
    }
    return CardGetCardGameViewItem;
}());

var RoundRoundHandGetCardGameViewItem = /** @class */ (function () {
    function RoundRoundHandGetCardGameViewItem() {
    }
    return RoundRoundHandGetCardGameViewItem;
}());



/***/ }),

/***/ "./src/app/models/requestModels/request-get-first-deal-game-view.ts":
/*!**************************************************************************!*\
  !*** ./src/app/models/requestModels/request-get-first-deal-game-view.ts ***!
  \**************************************************************************/
/*! exports provided: RequestGetFirstDealGameView, PlayerRoundHandGetFirstDealGameViewItem, CardGetFirstDealGameViewItem, RoundRoundHandGetFirstDealGameViewItem */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RequestGetFirstDealGameView", function() { return RequestGetFirstDealGameView; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PlayerRoundHandGetFirstDealGameViewItem", function() { return PlayerRoundHandGetFirstDealGameViewItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CardGetFirstDealGameViewItem", function() { return CardGetFirstDealGameViewItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RoundRoundHandGetFirstDealGameViewItem", function() { return RoundRoundHandGetFirstDealGameViewItem; });
var RequestGetFirstDealGameView = /** @class */ (function () {
    function RequestGetFirstDealGameView() {
    }
    return RequestGetFirstDealGameView;
}());

var PlayerRoundHandGetFirstDealGameViewItem = /** @class */ (function () {
    function PlayerRoundHandGetFirstDealGameViewItem() {
    }
    return PlayerRoundHandGetFirstDealGameViewItem;
}());

var CardGetFirstDealGameViewItem = /** @class */ (function () {
    function CardGetFirstDealGameViewItem() {
    }
    return CardGetFirstDealGameViewItem;
}());

var RoundRoundHandGetFirstDealGameViewItem = /** @class */ (function () {
    function RoundRoundHandGetFirstDealGameViewItem() {
    }
    return RoundRoundHandGetFirstDealGameViewItem;
}());



/***/ }),

/***/ "./src/app/models/responseModels/response-game-process-game.model.ts":
/*!***************************************************************************!*\
  !*** ./src/app/models/responseModels/response-game-process-game.model.ts ***!
  \***************************************************************************/
/*! exports provided: ResponseGameProcessGameView, PlayerGameProcessGameViewItem, PlayerRoundHandGameProcessGameViewItem, CardGameProcessGameViewItem, GameGameProcessGameViewItem, RoundGameProcessGameViewItem */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ResponseGameProcessGameView", function() { return ResponseGameProcessGameView; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PlayerGameProcessGameViewItem", function() { return PlayerGameProcessGameViewItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PlayerRoundHandGameProcessGameViewItem", function() { return PlayerRoundHandGameProcessGameViewItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CardGameProcessGameViewItem", function() { return CardGameProcessGameViewItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GameGameProcessGameViewItem", function() { return GameGameProcessGameViewItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RoundGameProcessGameViewItem", function() { return RoundGameProcessGameViewItem; });
var ResponseGameProcessGameView = /** @class */ (function () {
    function ResponseGameProcessGameView() {
    }
    return ResponseGameProcessGameView;
}());

var PlayerGameProcessGameViewItem = /** @class */ (function () {
    function PlayerGameProcessGameViewItem() {
    }
    return PlayerGameProcessGameViewItem;
}());

var PlayerRoundHandGameProcessGameViewItem = /** @class */ (function () {
    function PlayerRoundHandGameProcessGameViewItem() {
    }
    return PlayerRoundHandGameProcessGameViewItem;
}());

var CardGameProcessGameViewItem = /** @class */ (function () {
    function CardGameProcessGameViewItem() {
    }
    return CardGameProcessGameViewItem;
}());

var GameGameProcessGameViewItem = /** @class */ (function () {
    function GameGameProcessGameViewItem() {
    }
    return GameGameProcessGameViewItem;
}());

var RoundGameProcessGameViewItem = /** @class */ (function () {
    function RoundGameProcessGameViewItem() {
    }
    return RoundGameProcessGameViewItem;
}());



/***/ }),

/***/ "./src/app/services/http-game-process.servise.ts":
/*!*******************************************************!*\
  !*** ./src/app/services/http-game-process.servise.ts ***!
  \*******************************************************/
/*! exports provided: HttpGameProcessService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HttpGameProcessService", function() { return HttpGameProcessService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var HttpGameProcessService = /** @class */ (function () {
    function HttpGameProcessService(http) {
        this.http = http;
        this.urlGetCard = '/Game/GetCard';
        this.urlGetFirstDeal = '/Game/GetFirstDeal';
        this.urlGetBotLogic = '/Game/BotAndDealerLogic';
        this.urlGetWinner = '/Game/FindWinner';
        this.urlGetNewRound = '/Game/NewRound';
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
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], HttpGameProcessService);
    return HttpGameProcessService;
}());



/***/ })

}]);
//# sourceMappingURL=default~game-process-game-process-module~start-game-options-start-game-options-module.js.map