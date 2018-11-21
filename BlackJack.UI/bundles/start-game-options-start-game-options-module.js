(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["start-game-options-start-game-options-module"],{

/***/ "./src/app/models/requestModels/request-game-start-options-game.model.ts":
/*!*******************************************************************************!*\
  !*** ./src/app/models/requestModels/request-game-start-options-game.model.ts ***!
  \*******************************************************************************/
/*! exports provided: RequestGameStartOptionsView */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RequestGameStartOptionsView", function() { return RequestGameStartOptionsView; });
var RequestGameStartOptionsView = /** @class */ (function () {
    function RequestGameStartOptionsView() {
    }
    return RequestGameStartOptionsView;
}());



/***/ }),

/***/ "./src/app/services/http-start-game-options.service.ts":
/*!*************************************************************!*\
  !*** ./src/app/services/http-start-game-options.service.ts ***!
  \*************************************************************/
/*! exports provided: HttpStartGameOptionsService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HttpStartGameOptionsService", function() { return HttpStartGameOptionsService; });
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


var HttpStartGameOptionsService = /** @class */ (function () {
    function HttpStartGameOptionsService(http) {
        this.http = http;
        this.urlGetStartOptions = '/Game/GameStartoptions';
        this.urlPostStartOptions = '/Game/GameStartoptions';
    }
    HttpStartGameOptionsService.prototype.HttpGetStartOptions = function () {
        return this.http.get(this.urlGetStartOptions);
    };
    HttpStartGameOptionsService.prototype.HttpPostStartOptions = function (model) {
        return this.http.post(this.urlPostStartOptions, model);
    };
    HttpStartGameOptionsService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], HttpStartGameOptionsService);
    return HttpStartGameOptionsService;
}());



/***/ }),

/***/ "./src/app/start-game-options/start-game-options-routing.module.ts":
/*!*************************************************************************!*\
  !*** ./src/app/start-game-options/start-game-options-routing.module.ts ***!
  \*************************************************************************/
/*! exports provided: StartGameOptionsRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StartGameOptionsRoutingModule", function() { return StartGameOptionsRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var src_app_start_game_options_start_game_options_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/start-game-options/start-game-options.component */ "./src/app/start-game-options/start-game-options.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    { path: '', component: src_app_start_game_options_start_game_options_component__WEBPACK_IMPORTED_MODULE_2__["StartGameOptionsComponent"] }
];
var StartGameOptionsRoutingModule = /** @class */ (function () {
    function StartGameOptionsRoutingModule() {
    }
    StartGameOptionsRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
        })
    ], StartGameOptionsRoutingModule);
    return StartGameOptionsRoutingModule;
}());



/***/ }),

/***/ "./src/app/start-game-options/start-game-options.component.css":
/*!*********************************************************************!*\
  !*** ./src/app/start-game-options/start-game-options.component.css ***!
  \*********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".DropDownWidth{\r\n    width: 350px;\r\n}\r\n\r\nbody{\r\n    background-color: black;\r\n}"

/***/ }),

/***/ "./src/app/start-game-options/start-game-options.component.html":
/*!**********************************************************************!*\
  !*** ./src/app/start-game-options/start-game-options.component.html ***!
  \**********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"text-center container\">\r\n    <br>\r\n    <kendo-window title=\"Please enter game options\" *ngIf=\"opened\" [minWidth]=\"250\" [width]=\"450\">\r\n        <form class=\"k-form\">\r\n            <fieldset>\r\n                <legend>Game Options</legend>\r\n                <div class=\"k-form-field text-center\">\r\n                    <label for=\"Names\">PlayerName</label>\r\n                    <kendo-combobox class=\"DropDownWidth\" #playerNameInput [data]=\"listPlayersName\" [value]='' [allowCustom]='true' id=\"Names\">\r\n                    </kendo-combobox>\r\n                </div>\r\n                <hr>\r\n                <div class=\"k-form-field\">\r\n                    <label for=\"BotsAmount\">Bots Amount</label>\r\n                    <kendo-dropdownlist class=\"DropDownWidth\" #botsAmountInput [data]=\"botsAmount\" [value]=\"\" id=\"BotsAmount\">\r\n                    </kendo-dropdownlist>\r\n                </div>\r\n            </fieldset>\r\n            <div class=\"text-right\">\r\n                <button type=\"button\" class=\"k-button k-primary\" (click)=\"submit(playerNameInput.value, botsAmountInput.value)\">Submit</button>\r\n            </div>\r\n        </form>\r\n    </kendo-window>\r\n    <br>\r\n</div>\r\n<app-game-process [model]='responseModel'></app-game-process>\r\n"

/***/ }),

/***/ "./src/app/start-game-options/start-game-options.component.ts":
/*!********************************************************************!*\
  !*** ./src/app/start-game-options/start-game-options.component.ts ***!
  \********************************************************************/
/*! exports provided: StartGameOptionsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StartGameOptionsComponent", function() { return StartGameOptionsComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var src_app_services_http_start_game_options_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/services/http-start-game-options.service */ "./src/app/services/http-start-game-options.service.ts");
/* harmony import */ var src_app_models_requestModels_request_game_start_options_game_model__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/models/requestModels/request-game-start-options-game.model */ "./src/app/models/requestModels/request-game-start-options-game.model.ts");
/* harmony import */ var src_app_services_http_game_process_servise__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/http-game-process.servise */ "./src/app/services/http-game-process.servise.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var StartGameOptionsComponent = /** @class */ (function () {
    function StartGameOptionsComponent(service) {
        this.service = service;
        this.botsAmount = [0, 1, 2, 3, 4, 5];
        this.opened = true;
        this.reqModel = new src_app_models_requestModels_request_game_start_options_game_model__WEBPACK_IMPORTED_MODULE_2__["RequestGameStartOptionsView"]();
    }
    StartGameOptionsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.service.HttpGetStartOptions().subscribe(function (data) {
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
        this.service.HttpPostStartOptions(this.reqModel).subscribe(function (data) {
            _this.responseModel = data;
        });
        this.close();
    };
    StartGameOptionsComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-start-game-options',
            template: __webpack_require__(/*! ./start-game-options.component.html */ "./src/app/start-game-options/start-game-options.component.html"),
            styles: [__webpack_require__(/*! ./start-game-options.component.css */ "./src/app/start-game-options/start-game-options.component.css")],
            providers: [src_app_services_http_start_game_options_service__WEBPACK_IMPORTED_MODULE_1__["HttpStartGameOptionsService"], src_app_services_http_game_process_servise__WEBPACK_IMPORTED_MODULE_3__["HttpGameProcessService"]]
        }),
        __metadata("design:paramtypes", [src_app_services_http_start_game_options_service__WEBPACK_IMPORTED_MODULE_1__["HttpStartGameOptionsService"]])
    ], StartGameOptionsComponent);
    return StartGameOptionsComponent;
}());



/***/ }),

/***/ "./src/app/start-game-options/start-game-options.module.ts":
/*!*****************************************************************!*\
  !*** ./src/app/start-game-options/start-game-options.module.ts ***!
  \*****************************************************************/
/*! exports provided: StartGameOptionsModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StartGameOptionsModule", function() { return StartGameOptionsModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _progress_kendo_angular_dropdowns__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @progress/kendo-angular-dropdowns */ "./node_modules/@progress/kendo-angular-dropdowns/dist/es/index.js");
/* harmony import */ var _progress_kendo_angular_dialog__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @progress/kendo-angular-dialog */ "./node_modules/@progress/kendo-angular-dialog/dist/es/index.js");
/* harmony import */ var _progress_kendo_angular_buttons__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @progress/kendo-angular-buttons */ "./node_modules/@progress/kendo-angular-buttons/dist/es/index.js");
/* harmony import */ var src_app_start_game_options_start_game_options_routing_module__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! src/app/start-game-options/start-game-options-routing.module */ "./src/app/start-game-options/start-game-options-routing.module.ts");
/* harmony import */ var src_app_start_game_options_start_game_options_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! src/app/start-game-options/start-game-options.component */ "./src/app/start-game-options/start-game-options.component.ts");
/* harmony import */ var src_app_game_process_game_process_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! src/app/game-process/game-process.component */ "./src/app/game-process/game-process.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};










var StartGameOptionsModule = /** @class */ (function () {
    function StartGameOptionsModule() {
    }
    StartGameOptionsModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                src_app_start_game_options_start_game_options_routing_module__WEBPACK_IMPORTED_MODULE_7__["StartGameOptionsRoutingModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormsModule"],
                _progress_kendo_angular_dropdowns__WEBPACK_IMPORTED_MODULE_4__["DropDownsModule"],
                _progress_kendo_angular_dialog__WEBPACK_IMPORTED_MODULE_5__["WindowModule"],
                _progress_kendo_angular_buttons__WEBPACK_IMPORTED_MODULE_6__["ButtonsModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClientModule"]
            ],
            declarations: [src_app_start_game_options_start_game_options_component__WEBPACK_IMPORTED_MODULE_8__["StartGameOptionsComponent"], src_app_game_process_game_process_component__WEBPACK_IMPORTED_MODULE_9__["GameProcessComponent"]]
        })
    ], StartGameOptionsModule);
    return StartGameOptionsModule;
}());



/***/ })

}]);
//# sourceMappingURL=start-game-options-start-game-options-module.js.map