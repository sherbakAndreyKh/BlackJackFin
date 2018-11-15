(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["game-process-game-process-module"],{

/***/ "./src/app/game-process/game-process-routing.module.ts":
/*!*************************************************************!*\
  !*** ./src/app/game-process/game-process-routing.module.ts ***!
  \*************************************************************/
/*! exports provided: GameProcessRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GameProcessRoutingModule", function() { return GameProcessRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _game_process_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./game-process.component */ "./src/app/game-process/game-process.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    { path: '', component: _game_process_component__WEBPACK_IMPORTED_MODULE_2__["GameProcessComponent"] }
];
var GameProcessRoutingModule = /** @class */ (function () {
    function GameProcessRoutingModule() {
    }
    GameProcessRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
        })
    ], GameProcessRoutingModule);
    return GameProcessRoutingModule;
}());



/***/ }),

/***/ "./src/app/game-process/game-process.module.ts":
/*!*****************************************************!*\
  !*** ./src/app/game-process/game-process.module.ts ***!
  \*****************************************************/
/*! exports provided: GameProcessModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GameProcessModule", function() { return GameProcessModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _game_process_routing_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./game-process-routing.module */ "./src/app/game-process/game-process-routing.module.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var GameProcessModule = /** @class */ (function () {
    function GameProcessModule() {
    }
    GameProcessModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _game_process_routing_module__WEBPACK_IMPORTED_MODULE_2__["GameProcessRoutingModule"]
            ],
            declarations: []
        })
    ], GameProcessModule);
    return GameProcessModule;
}());



/***/ })

}]);
//# sourceMappingURL=game-process-game-process-module.js.map