(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var router_1 = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
var start_game_options_component_1 = __webpack_require__(/*! ./start-game-options/start-game-options.component */ "./src/app/start-game-options/start-game-options.component.ts");
var welcomeScreen_component_1 = __webpack_require__(/*! ./welcomeScreen/welcomeScreen.component */ "./src/app/welcomeScreen/welcomeScreen.component.ts");
var game_process_component_1 = __webpack_require__(/*! ./game-process/game-process.component */ "./src/app/game-process/game-process.component.ts");
var routes = [
    { path: '', redirectTo: 'welcome', pathMatch: 'full' },
    { path: 'welcome', component: welcomeScreen_component_1.WelcomeScreenComponent },
    { path: 'startOptions', component: start_game_options_component_1.StartGameOptionsComponent },
    { path: 'gameProcess', component: game_process_component_1.GameProcessComponent },
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        core_1.NgModule({
            imports: [router_1.RouterModule.forRoot(routes)],
            exports: [router_1.RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
exports.AppRoutingModule = AppRoutingModule;


/***/ }),

/***/ "./src/app/app.component.css":
/*!***********************************!*\
  !*** ./src/app/app.component.css ***!
  \***********************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/app.component.html":
/*!************************************!*\
  !*** ./src/app/app.component.html ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<router-outlet></router-outlet>"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var AppComponent = /** @class */ (function () {
    function AppComponent() {
        this.title = 'BlackJackUI';
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: 'app-root',
            template: __webpack_require__(/*! ./app.component.html */ "./src/app/app.component.html"),
            styles: [__webpack_require__(/*! ./app.component.css */ "./src/app/app.component.css")]
        })
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;


/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var forms_1 = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
var app_component_1 = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
var welcomeScreen_component_1 = __webpack_require__(/*! ./welcomeScreen/welcomeScreen.component */ "./src/app/welcomeScreen/welcomeScreen.component.ts");
var start_game_options_component_1 = __webpack_require__(/*! ./start-game-options/start-game-options.component */ "./src/app/start-game-options/start-game-options.component.ts");
var app_routing_module_1 = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
var game_process_component_1 = __webpack_require__(/*! ./game-process/game-process.component */ "./src/app/game-process/game-process.component.ts");
var http_1 = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            declarations: [
                app_component_1.AppComponent,
                welcomeScreen_component_1.WelcomeScreenComponent,
                start_game_options_component_1.StartGameOptionsComponent,
                game_process_component_1.GameProcessComponent,
            ],
            imports: [
                app_routing_module_1.AppRoutingModule,
                platform_browser_1.BrowserModule,
                http_1.HttpClientModule,
                forms_1.FormsModule
            ],
            providers: [],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;


/***/ }),

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

module.exports = "<p>\n  game-process works!\n</p>\n"

/***/ }),

/***/ "./src/app/game-process/game-process.component.ts":
/*!********************************************************!*\
  !*** ./src/app/game-process/game-process.component.ts ***!
  \********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var GameProcessComponent = /** @class */ (function () {
    function GameProcessComponent() {
    }
    GameProcessComponent.prototype.ngOnInit = function () {
    };
    GameProcessComponent = __decorate([
        core_1.Component({
            selector: 'app-game-process',
            template: __webpack_require__(/*! ./game-process.component.html */ "./src/app/game-process/game-process.component.html"),
            styles: [__webpack_require__(/*! ./game-process.component.css */ "./src/app/game-process/game-process.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], GameProcessComponent);
    return GameProcessComponent;
}());
exports.GameProcessComponent = GameProcessComponent;


/***/ }),

/***/ "./src/app/start-game-options/start-game-options.component.css":
/*!*********************************************************************!*\
  !*** ./src/app/start-game-options/start-game-options.component.css ***!
  \*********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/start-game-options/start-game-options.component.html":
/*!**********************************************************************!*\
  !*** ./src/app/start-game-options/start-game-options.component.html ***!
  \**********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1 class=\"text-center\">Enter Start Game Options</h1>\r\n\r\n<div class=\"text-center\">\r\n    <label for=\"Name\">Player Name</label>\r\n    <input type=\"text\" id=\"Name\" list=\"Options\">\r\n    <datalist id=\"Options\">\r\n    <option  *ngFor=\"let players of model.Players\">{{players.PlayerName}}</option>\r\n    </datalist>\r\n    <br />\r\n    <label for=\"AmountBot\">Amount Bot</label>\r\n    <select id=\"AmountBot\">\r\n        <option value=\"1\">1</option>\r\n        <option value=\"2\">2</option>\r\n        <option value=\"3\">3</option>\r\n        <option value=\"4\">4</option>\r\n        <option value=\"5\">5</option>\r\n    </select>\r\n    <br />\r\n    <a routerLink=\"/gameProcess\">Start Game</a>\r\n</div>\r\n\r\n"

/***/ }),

/***/ "./src/app/start-game-options/start-game-options.component.ts":
/*!********************************************************************!*\
  !*** ./src/app/start-game-options/start-game-options.component.ts ***!
  \********************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var http_1 = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
var StartGameOptionsComponent = /** @class */ (function () {
    function StartGameOptionsComponent(http) {
        this.http = http;
    }
    StartGameOptionsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.http.get('http://localhost:50219/Game/GameStartOptions').subscribe(function (data) { return _this.model = data; });
    };
    StartGameOptionsComponent = __decorate([
        core_1.Component({
            selector: 'app-start-game-options',
            template: __webpack_require__(/*! ./start-game-options.component.html */ "./src/app/start-game-options/start-game-options.component.html"),
            styles: [__webpack_require__(/*! ./start-game-options.component.css */ "./src/app/start-game-options/start-game-options.component.css")]
        }),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], StartGameOptionsComponent);
    return StartGameOptionsComponent;
}());
exports.StartGameOptionsComponent = StartGameOptionsComponent;


/***/ }),

/***/ "./src/app/welcomeScreen/welcomeScreen.component.css":
/*!***********************************************************!*\
  !*** ./src/app/welcomeScreen/welcomeScreen.component.css ***!
  \***********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/welcomeScreen/welcomeScreen.component.html":
/*!************************************************************!*\
  !*** ./src/app/welcomeScreen/welcomeScreen.component.html ***!
  \************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"text-center\">\r\n    <h2>Welcome To BlackJack</h2>\r\n\r\n    <a routerLink=\"/startOptions\">Go To Game</a>\r\n</div>"

/***/ }),

/***/ "./src/app/welcomeScreen/welcomeScreen.component.ts":
/*!**********************************************************!*\
  !*** ./src/app/welcomeScreen/welcomeScreen.component.ts ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var WelcomeScreenComponent = /** @class */ (function () {
    function WelcomeScreenComponent() {
    }
    WelcomeScreenComponent.prototype.ngModule = function () { };
    WelcomeScreenComponent = __decorate([
        core_1.Component({
            selector: 'app-welcome-screen',
            template: __webpack_require__(/*! ./welcomeScreen.component.html */ "./src/app/welcomeScreen/welcomeScreen.component.html"),
            styles: [__webpack_require__(/*! ./welcomeScreen.component.css */ "./src/app/welcomeScreen/welcomeScreen.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], WelcomeScreenComponent);
    return WelcomeScreenComponent;
}());
exports.WelcomeScreenComponent = WelcomeScreenComponent;


/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
Object.defineProperty(exports, "__esModule", { value: true });
exports.environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var platform_browser_dynamic_1 = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
var app_module_1 = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
var environment_1 = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");
if (environment_1.environment.production) {
    core_1.enableProdMode();
}
platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(app_module_1.AppModule)
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Users\Anuitex-103\source\repos\BlackJack\BlackJack.UI\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map