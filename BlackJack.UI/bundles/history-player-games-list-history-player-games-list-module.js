(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["history-player-games-list-history-player-games-list-module"],{

/***/ "./src/app/history-player-games-list/history-player-games-list-routing.module.ts":
/*!***************************************************************************************!*\
  !*** ./src/app/history-player-games-list/history-player-games-list-routing.module.ts ***!
  \***************************************************************************************/
/*! exports provided: HistoryPlayerGamesListRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HistoryPlayerGamesListRoutingModule", function() { return HistoryPlayerGamesListRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var src_app_history_player_games_list_history_player_games_list_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/history-player-games-list/history-player-games-list.component */ "./src/app/history-player-games-list/history-player-games-list.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    { path: '', component: src_app_history_player_games_list_history_player_games_list_component__WEBPACK_IMPORTED_MODULE_2__["HistoryPlayerGamesListComponent"] }
];
var HistoryPlayerGamesListRoutingModule = /** @class */ (function () {
    function HistoryPlayerGamesListRoutingModule() {
    }
    HistoryPlayerGamesListRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
        })
    ], HistoryPlayerGamesListRoutingModule);
    return HistoryPlayerGamesListRoutingModule;
}());



/***/ }),

/***/ "./src/app/history-player-games-list/history-player-games-list.component.css":
/*!***********************************************************************************!*\
  !*** ./src/app/history-player-games-list/history-player-games-list.component.css ***!
  \***********************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/history-player-games-list/history-player-games-list.component.html":
/*!************************************************************************************!*\
  !*** ./src/app/history-player-games-list/history-player-games-list.component.html ***!
  \************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"container\">\r\n    <kendo-grid [data]=\"model?.games\" (details)=\"editHandler($event)\">\r\n        <kendo-grid-column field=\"id\" width=\"10\"></kendo-grid-column>\r\n        <kendo-grid-column field=\"number\" title=\"GameNumber\" width=\"30\"></kendo-grid-column>\r\n        <kendo-grid-column field=\"roundsAmount\" title=\"Rounds Amount\" width=\"30\"></kendo-grid-column>\r\n        <kendo-grid-command-column title=\"Command\" width=\"30\">\r\n            <ng-template kendoGridCellTemplate let-data>\r\n                <a routerLink=\"/getRounds/{{data.id}}\">Details</a>\r\n            </ng-template>\r\n        </kendo-grid-command-column>\r\n    </kendo-grid>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/history-player-games-list/history-player-games-list.component.ts":
/*!**********************************************************************************!*\
  !*** ./src/app/history-player-games-list/history-player-games-list.component.ts ***!
  \**********************************************************************************/
/*! exports provided: HistoryPlayerGamesListComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HistoryPlayerGamesListComponent", function() { return HistoryPlayerGamesListComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var src_app_services_http_history_player_games_list_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/services/http-history-player-games-list.service */ "./src/app/services/http-history-player-games-list.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var HistoryPlayerGamesListComponent = /** @class */ (function () {
    function HistoryPlayerGamesListComponent(route, http, location, service) {
        this.route = route;
        this.http = http;
        this.location = location;
        this.service = service;
    }
    HistoryPlayerGamesListComponent.prototype.ngOnInit = function () {
        this.getPlayerGames();
    };
    HistoryPlayerGamesListComponent.prototype.getPlayerGames = function () {
        var _this = this;
        var id = +this.route.snapshot.paramMap.get('id');
        this.service.httpGetPlayerGames(id).subscribe(function (data) { return _this.model = data; }, function (error) { return console.log(error); });
    };
    HistoryPlayerGamesListComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-history-player-games-list',
            template: __webpack_require__(/*! ./history-player-games-list.component.html */ "./src/app/history-player-games-list/history-player-games-list.component.html"),
            styles: [__webpack_require__(/*! ./history-player-games-list.component.css */ "./src/app/history-player-games-list/history-player-games-list.component.css")],
            providers: [src_app_services_http_history_player_games_list_service__WEBPACK_IMPORTED_MODULE_4__["HttpHistoryPlayerGamesListService"]]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
            _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClient"],
            _angular_common__WEBPACK_IMPORTED_MODULE_2__["Location"],
            src_app_services_http_history_player_games_list_service__WEBPACK_IMPORTED_MODULE_4__["HttpHistoryPlayerGamesListService"]])
    ], HistoryPlayerGamesListComponent);
    return HistoryPlayerGamesListComponent;
}());



/***/ }),

/***/ "./src/app/history-player-games-list/history-player-games-list.module.ts":
/*!*******************************************************************************!*\
  !*** ./src/app/history-player-games-list/history-player-games-list.module.ts ***!
  \*******************************************************************************/
/*! exports provided: HistoryPlayerGamesListModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HistoryPlayerGamesListModule", function() { return HistoryPlayerGamesListModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _progress_kendo_angular_grid__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @progress/kendo-angular-grid */ "./node_modules/@progress/kendo-angular-grid/dist/es/index.js");
/* harmony import */ var src_app_history_player_games_list_history_player_games_list_routing_module__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/history-player-games-list/history-player-games-list-routing.module */ "./src/app/history-player-games-list/history-player-games-list-routing.module.ts");
/* harmony import */ var src_app_history_player_games_list_history_player_games_list_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/history-player-games-list/history-player-games-list.component */ "./src/app/history-player-games-list/history-player-games-list.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






var HistoryPlayerGamesListModule = /** @class */ (function () {
    function HistoryPlayerGamesListModule() {
    }
    HistoryPlayerGamesListModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                src_app_history_player_games_list_history_player_games_list_routing_module__WEBPACK_IMPORTED_MODULE_4__["HistoryPlayerGamesListRoutingModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClientModule"],
                _progress_kendo_angular_grid__WEBPACK_IMPORTED_MODULE_3__["GridModule"]
            ],
            declarations: [src_app_history_player_games_list_history_player_games_list_component__WEBPACK_IMPORTED_MODULE_5__["HistoryPlayerGamesListComponent"]]
        })
    ], HistoryPlayerGamesListModule);
    return HistoryPlayerGamesListModule;
}());



/***/ }),

/***/ "./src/app/services/http-history-player-games-list.service.ts":
/*!********************************************************************!*\
  !*** ./src/app/services/http-history-player-games-list.service.ts ***!
  \********************************************************************/
/*! exports provided: HttpHistoryPlayerGamesListService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HttpHistoryPlayerGamesListService", function() { return HttpHistoryPlayerGamesListService; });
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


var HttpHistoryPlayerGamesListService = /** @class */ (function () {
    function HttpHistoryPlayerGamesListService(http) {
        this.http = http;
        this.urlGetPlayerGames = "history/getgames/";
    }
    HttpHistoryPlayerGamesListService.prototype.httpGetPlayerGames = function (id) {
        return this.http.get(this.urlGetPlayerGames + id);
    };
    HttpHistoryPlayerGamesListService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], HttpHistoryPlayerGamesListService);
    return HttpHistoryPlayerGamesListService;
}());



/***/ })

}]);
//# sourceMappingURL=history-player-games-list-history-player-games-list-module.js.map