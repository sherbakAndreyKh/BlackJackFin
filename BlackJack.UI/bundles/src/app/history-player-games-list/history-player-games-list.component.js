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
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';
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
        debugger;
        this.http.get("http://localhost:50219/history/getgames/" + id).subscribe(function (data) { return _this.model = data; });
    };
    HistoryPlayerGamesListComponent = __decorate([
        Component({
            selector: 'app-history-player-games-list',
            templateUrl: './history-player-games-list.component.html',
            styleUrls: ['./history-player-games-list.component.css']
        }),
        __metadata("design:paramtypes", [ActivatedRoute,
            HttpClient,
            Location])
    ], HistoryPlayerGamesListComponent);
    return HistoryPlayerGamesListComponent;
}());
export { HistoryPlayerGamesListComponent };
//# sourceMappingURL=history-player-games-list.component.js.map