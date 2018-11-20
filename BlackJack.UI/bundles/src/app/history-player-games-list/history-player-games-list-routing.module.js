var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HistoryPlayerGamesListComponent } from 'src/app/history-player-games-list/history-player-games-list.component';
var routes = [
    { path: '', component: HistoryPlayerGamesListComponent }
];
var HistoryPlayerGamesListRoutingModule = /** @class */ (function () {
    function HistoryPlayerGamesListRoutingModule() {
    }
    HistoryPlayerGamesListRoutingModule = __decorate([
        NgModule({
            imports: [RouterModule.forChild(routes)],
            exports: [RouterModule]
        })
    ], HistoryPlayerGamesListRoutingModule);
    return HistoryPlayerGamesListRoutingModule;
}());
export { HistoryPlayerGamesListRoutingModule };
//# sourceMappingURL=history-player-games-list-routing.module.js.map