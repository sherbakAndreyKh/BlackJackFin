(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["welcome-screen-welcome-screen-module"],{

/***/ "./src/app/welcome-screen/welcome-screen-routing.module.ts":
/*!*****************************************************************!*\
  !*** ./src/app/welcome-screen/welcome-screen-routing.module.ts ***!
  \*****************************************************************/
/*! exports provided: WelcomeScreenRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WelcomeScreenRoutingModule", function() { return WelcomeScreenRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var src_app_welcome_screen_welcome_screen_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/welcome-screen/welcome-screen.component */ "./src/app/welcome-screen/welcome-screen.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    { path: '', component: src_app_welcome_screen_welcome_screen_component__WEBPACK_IMPORTED_MODULE_2__["WelcomeScreenComponent"] }
];
var WelcomeScreenRoutingModule = /** @class */ (function () {
    function WelcomeScreenRoutingModule() {
    }
    WelcomeScreenRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
        })
    ], WelcomeScreenRoutingModule);
    return WelcomeScreenRoutingModule;
}());



/***/ }),

/***/ "./src/app/welcome-screen/welcome-screen.component.css":
/*!*************************************************************!*\
  !*** ./src/app/welcome-screen/welcome-screen.component.css ***!
  \*************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/welcome-screen/welcome-screen.component.html":
/*!**************************************************************!*\
  !*** ./src/app/welcome-screen/welcome-screen.component.html ***!
  \**************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"text-center container\">\r\n    <h1 class=\"text-center\">Welcome to Black-Jack game</h1>\r\n    <a routerLink=\"/startOptions\">StartGame</a>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/welcome-screen/welcome-screen.component.ts":
/*!************************************************************!*\
  !*** ./src/app/welcome-screen/welcome-screen.component.ts ***!
  \************************************************************/
/*! exports provided: WelcomeScreenComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WelcomeScreenComponent", function() { return WelcomeScreenComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var WelcomeScreenComponent = /** @class */ (function () {
    function WelcomeScreenComponent() {
    }
    WelcomeScreenComponent.prototype.ngOnInit = function () {
    };
    WelcomeScreenComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-welcome-screen',
            template: __webpack_require__(/*! ./welcome-screen.component.html */ "./src/app/welcome-screen/welcome-screen.component.html"),
            styles: [__webpack_require__(/*! ./welcome-screen.component.css */ "./src/app/welcome-screen/welcome-screen.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], WelcomeScreenComponent);
    return WelcomeScreenComponent;
}());



/***/ }),

/***/ "./src/app/welcome-screen/welcome-screen.module.ts":
/*!*********************************************************!*\
  !*** ./src/app/welcome-screen/welcome-screen.module.ts ***!
  \*********************************************************/
/*! exports provided: WelcomeScreenModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WelcomeScreenModule", function() { return WelcomeScreenModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var src_app_welcome_screen_welcome_screen_routing_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/welcome-screen/welcome-screen-routing.module */ "./src/app/welcome-screen/welcome-screen-routing.module.ts");
/* harmony import */ var src_app_welcome_screen_welcome_screen_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/welcome-screen/welcome-screen.component */ "./src/app/welcome-screen/welcome-screen.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var WelcomeScreenModule = /** @class */ (function () {
    function WelcomeScreenModule() {
    }
    WelcomeScreenModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                src_app_welcome_screen_welcome_screen_routing_module__WEBPACK_IMPORTED_MODULE_2__["WelcomeScreenRoutingModule"]
            ],
            declarations: [src_app_welcome_screen_welcome_screen_component__WEBPACK_IMPORTED_MODULE_3__["WelcomeScreenComponent"]]
        })
    ], WelcomeScreenModule);
    return WelcomeScreenModule;
}());



/***/ })

}]);
//# sourceMappingURL=welcome-screen-welcome-screen-module.js.map