(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["history-player-list-history-player-list-module"],{

/***/ "./src/app/history-player-list/history-player-list-routing.module.ts":
/*!***************************************************************************!*\
  !*** ./src/app/history-player-list/history-player-list-routing.module.ts ***!
  \***************************************************************************/
/*! exports provided: HistoryPlayerListRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HistoryPlayerListRoutingModule", function() { return HistoryPlayerListRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _history_player_list_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./history-player-list.component */ "./src/app/history-player-list/history-player-list.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    { path: '', component: _history_player_list_component__WEBPACK_IMPORTED_MODULE_2__["HistoryPlayerListComponent"] }
];
var HistoryPlayerListRoutingModule = /** @class */ (function () {
    function HistoryPlayerListRoutingModule() {
    }
    HistoryPlayerListRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
        })
    ], HistoryPlayerListRoutingModule);
    return HistoryPlayerListRoutingModule;
}());



/***/ }),

/***/ "./src/app/history-player-list/history-player-list.component.css":
/*!***********************************************************************!*\
  !*** ./src/app/history-player-list/history-player-list.component.css ***!
  \***********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/history-player-list/history-player-list.component.html":
/*!************************************************************************!*\
  !*** ./src/app/history-player-list/history-player-list.component.html ***!
  \************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"container\">\n<kendo-grid [data]=\"model?.Players\" (details)=\"editHandler($event)\">\n  \n<kendo-grid-column field=\"Id\" width=\"10\"></kendo-grid-column>\n<kendo-grid-column  field=\"Name\" title=\"Name\" width=\"30\"></kendo-grid-column>\n<kendo-grid-column field=\"GameAmount\" title=\"Games\" width=\"30\"></kendo-grid-column>\n<kendo-grid-command-column title=\"Command\" width=\"30\">\n    <ng-template kendoGridCellTemplate>\n  <button routerLink=\"/getGames/{{id}}\">Details</button>\n  </ng-template>\n</kendo-grid-command-column>\n</kendo-grid>\n</div>\n"

/***/ }),

/***/ "./src/app/history-player-list/history-player-list.component.ts":
/*!**********************************************************************!*\
  !*** ./src/app/history-player-list/history-player-list.component.ts ***!
  \**********************************************************************/
/*! exports provided: HistoryPlayerListComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HistoryPlayerListComponent", function() { return HistoryPlayerListComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_http_history_player_list_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../services/http-history-player-list.service */ "./src/app/services/http-history-player-list.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var HistoryPlayerListComponent = /** @class */ (function () {
    function HistoryPlayerListComponent(service) {
        this.service = service;
    }
    HistoryPlayerListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.service.HttpGetPlayerList().subscribe(function (data) { return _this.model = data; });
    };
    HistoryPlayerListComponent.prototype.buttonClick = function (id) {
        debugger;
    };
    HistoryPlayerListComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-history-player-list',
            template: __webpack_require__(/*! ./history-player-list.component.html */ "./src/app/history-player-list/history-player-list.component.html"),
            styles: [__webpack_require__(/*! ./history-player-list.component.css */ "./src/app/history-player-list/history-player-list.component.css")],
            providers: [_services_http_history_player_list_service__WEBPACK_IMPORTED_MODULE_1__["HttpHistoryPlayerListService"]]
        }),
        __metadata("design:paramtypes", [_services_http_history_player_list_service__WEBPACK_IMPORTED_MODULE_1__["HttpHistoryPlayerListService"]])
    ], HistoryPlayerListComponent);
    return HistoryPlayerListComponent;
}());



/***/ }),

/***/ "./src/app/history-player-list/history-player-list.module.ts":
/*!*******************************************************************!*\
  !*** ./src/app/history-player-list/history-player-list.module.ts ***!
  \*******************************************************************/
/*! exports provided: HistoryPlayerListModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HistoryPlayerListModule", function() { return HistoryPlayerListModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _history_player_list_routing_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./history-player-list-routing.module */ "./src/app/history-player-list/history-player-list-routing.module.ts");
/* harmony import */ var _history_player_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./history-player-list.component */ "./src/app/history-player-list/history-player-list.component.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _progress_kendo_angular_grid__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @progress/kendo-angular-grid */ "./node_modules/@progress/kendo-angular-grid/dist/es/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






var HistoryPlayerListModule = /** @class */ (function () {
    function HistoryPlayerListModule() {
    }
    HistoryPlayerListModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _history_player_list_routing_module__WEBPACK_IMPORTED_MODULE_2__["HistoryPlayerListRoutingModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClientModule"],
                _progress_kendo_angular_grid__WEBPACK_IMPORTED_MODULE_5__["GridModule"]
            ],
            declarations: [_history_player_list_component__WEBPACK_IMPORTED_MODULE_3__["HistoryPlayerListComponent"]]
        })
    ], HistoryPlayerListModule);
    return HistoryPlayerListModule;
}());



/***/ }),

/***/ "./src/app/services/http-history-player-list.service.ts":
/*!**************************************************************!*\
  !*** ./src/app/services/http-history-player-list.service.ts ***!
  \**************************************************************/
/*! exports provided: HttpHistoryPlayerListService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HttpHistoryPlayerListService", function() { return HttpHistoryPlayerListService; });
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


var HttpHistoryPlayerListService = /** @class */ (function () {
    function HttpHistoryPlayerListService(http) {
        this.http = http;
        this.urlGet = 'http://localhost:50219/history/index';
    }
    HttpHistoryPlayerListService.prototype.HttpGetPlayerList = function () {
        return this.http.get(this.urlGet);
    };
    HttpHistoryPlayerListService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], HttpHistoryPlayerListService);
    return HttpHistoryPlayerListService;
}());



/***/ })

}]);
//# sourceMappingURL=history-player-list-history-player-list-module.js.map