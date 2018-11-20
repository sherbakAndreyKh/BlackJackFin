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
/* harmony import */ var _history_player_games_list_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./history-player-games-list.component */ "./src/app/history-player-games-list/history-player-games-list.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    { path: '', component: _history_player_games_list_component__WEBPACK_IMPORTED_MODULE_2__["HistoryPlayerGamesListComponent"] },
    { path: '', component: _history_player_games_list_component__WEBPACK_IMPORTED_MODULE_2__["HistoryPlayerGamesListComponent"] }
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

module.exports = "<p>\n  history-player-games-list works!\n</p>\n"

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
    function HistoryPlayerGamesListComponent(route, http, location) {
        this.route = route;
        this.http = http;
        this.location = location;
    }
    HistoryPlayerGamesListComponent.prototype.ngOnInit = function () {
        this.getPlayerGames();
    };
    HistoryPlayerGamesListComponent.prototype.getPlayerGames = function () {
        var _this = this;
        var id = +this.route.snapshot.paramMap.get('id');
        this.http.get("http://localhost:50219/history/getgames/" + id).subscribe(function (data) { return _this.model = data; });
    };
    HistoryPlayerGamesListComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-history-player-games-list',
            template: __webpack_require__(/*! ./history-player-games-list.component.html */ "./src/app/history-player-games-list/history-player-games-list.component.html"),
            styles: [__webpack_require__(/*! ./history-player-games-list.component.css */ "./src/app/history-player-games-list/history-player-games-list.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
            _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClient"],
            _angular_common__WEBPACK_IMPORTED_MODULE_2__["Location"]])
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
/* harmony import */ var _history_player_games_list_routing_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./history-player-games-list-routing.module */ "./src/app/history-player-games-list/history-player-games-list-routing.module.ts");
/* harmony import */ var _history_player_games_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./history-player-games-list.component */ "./src/app/history-player-games-list/history-player-games-list.component.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
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
                _history_player_games_list_routing_module__WEBPACK_IMPORTED_MODULE_2__["HistoryPlayerGamesListRoutingModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClientModule"]
            ],
            declarations: [_history_player_games_list_component__WEBPACK_IMPORTED_MODULE_3__["HistoryPlayerGamesListComponent"]]
        })
    ], HistoryPlayerGamesListModule);
    return HistoryPlayerGamesListModule;
}());



/***/ })

}]);
//# sourceMappingURL=history-player-games-list-history-player-games-list-module.js.map