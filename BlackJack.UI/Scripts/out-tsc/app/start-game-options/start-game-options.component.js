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
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
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
            templateUrl: './start-game-options.component.html',
            styleUrls: ['./start-game-options.component.css']
        }),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], StartGameOptionsComponent);
    return StartGameOptionsComponent;
}());
exports.StartGameOptionsComponent = StartGameOptionsComponent;
//# sourceMappingURL=start-game-options.component.js.map