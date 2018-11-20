(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["common"],{

/***/ "./src/app/game-process/game-process.component.css":
/*!*********************************************************!*\
  !*** ./src/app/game-process/game-process.component.css ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/game-process/game-process.component.html":
/*!**********************************************************!*\
  !*** ./src/app/game-process/game-process.component.html ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"text-center container \">\r\n    \r\n\r\n<h2>Player Name: {{model?.Player.Name}}</h2>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n      <h3 >Game Number: {{model?.Game.GameNumber}}</h3>\r\n    </div>\r\n    <div class=\"col-md-6\">\r\n      <h3>Round Number: {{model?.Round.RoundNumber}}</h3>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"player col-md-2\">\r\n        <p><span *ngFor=\"let card of model?.Player.PlayerRoundHand.Hand\">{{card.Name}} {{card.Suit}}, </span> </p>\r\n    <p>{{model?.Player.PlayerRoundHand.Score}}</p>\r\n    <h4>{{model?.Player.Name}}</h4>\r\n</div>\r\n<hr>\r\n\r\n<div *ngFor=\"let bot of model?.Bots \" class=\"player col-md-2\">\r\n    <p><span *ngFor=\"let card of bot?.PlayerRoundHand.Hand\">{{card.Name}} {{card.Suit}},</span> </p>\r\n    <p>{{bot.PlayerRoundHand.Score}}</p>\r\n    <h4>{{bot.Name}}</h4>\r\n</div>\r\n<hr>\r\n<div class=\"dealer col-md-2\">\r\n    <p><span *ngFor=\"let card of model?.Dealer.PlayerRoundHand.Hand\">{{card.Name}} {{card.Suit}},</span></p>\r\n    <p>{{model?.Dealer.PlayerRoundHand.Score}}</p>\r\n    <h4>{{model?.Dealer.Name}}</h4>\r\n</div>\r\n\r\n<div class=\"text-right\">\r\n    <button kendoButton (click)=\"getFirstDealClick()\">Start Game</button>\r\n    <button kendoButton (click)=\"getCardClick()\">Get Card</button>\r\n    <button kendoButton (click)=\"onButtonClick()\">Stop</button>\r\n</div>\r\n\r\n</div>"

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
/* harmony import */ var _models_responseModels_response_game_process_game_model__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../models/responseModels/response-game-process-game.model */ "./src/app/models/responseModels/response-game-process-game.model.ts");
/* harmony import */ var _services_http_game_process_servise__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../services/http-game-process.servise */ "./src/app/services/http-game-process.servise.ts");
/* harmony import */ var _models_requestModels_request_get_card_game_view__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../models/requestModels/request-get-card-game-view */ "./src/app/models/requestModels/request-get-card-game-view.ts");
/* harmony import */ var _models_requestModels_request_get_first_deal_game_view__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../models/requestModels/request-get-first-deal-game-view */ "./src/app/models/requestModels/request-get-first-deal-game-view.ts");
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
        this.getCardRequest = new _models_requestModels_request_get_card_game_view__WEBPACK_IMPORTED_MODULE_3__["RequestGetCardGameView"]();
        this.getFirstDealRequest = new _models_requestModels_request_get_first_deal_game_view__WEBPACK_IMPORTED_MODULE_4__["RequestGetFirstDealGameView"]();
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
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", _models_responseModels_response_game_process_game_model__WEBPACK_IMPORTED_MODULE_1__["ResponseGameProcessGameView"])
    ], GameProcessComponent.prototype, "model", void 0);
    GameProcessComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-game-process',
            template: __webpack_require__(/*! ./game-process.component.html */ "./src/app/game-process/game-process.component.html"),
            styles: [__webpack_require__(/*! ./game-process.component.css */ "./src/app/game-process/game-process.component.css")]
        }),
        __metadata("design:paramtypes", [_services_http_game_process_servise__WEBPACK_IMPORTED_MODULE_2__["HttpGameProcessService"]])
    ], GameProcessComponent);
    return GameProcessComponent;
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
        this.urlGetCard = 'http://localhost:50219/Game/GetCard';
        this.urlGetFirstDeal = 'http://localhost:50219/Game/GetFirstDeal';
    }
    HttpGameProcessService.prototype.HttpGetCard = function (model) {
        return this.http.post(this.urlGetCard, model);
    };
    HttpGameProcessService.prototype.HttpGetFirstDeal = function (model) {
        return this.http.post(this.urlGetFirstDeal, model);
    };
    HttpGameProcessService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], HttpGameProcessService);
    return HttpGameProcessService;
}());



/***/ })

}]);
//# sourceMappingURL=common.js.map