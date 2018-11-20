var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { HttpHistoryPlayerListService } from '../services/http-history-player-list.service';
var HistoryPlayerListComponent = /** @class */ (function () {
    function HistoryPlayerListComponent(service) {
        this.service = service;
    }
    HistoryPlayerListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.service.httpGetPlayerList().subscribe(function (data) { return _this.model = data; });
    };
    HistoryPlayerListComponent.prototype.buttonClick = function (id) {
        debugger;
    };
    HistoryPlayerListComponent = __decorate([
        Component({
            selector: 'app-history-player-list',
            templateUrl: './history-player-list.component.html',
            styleUrls: ['./history-player-list.component.css'],
            providers: [HttpHistoryPlayerListService]
        }),
        __metadata("design:paramtypes", [HttpHistoryPlayerListService])
    ], HistoryPlayerListComponent);
    return HistoryPlayerListComponent;
}());
export { HistoryPlayerListComponent };
//# sourceMappingURL=history-player-list.component.js.map