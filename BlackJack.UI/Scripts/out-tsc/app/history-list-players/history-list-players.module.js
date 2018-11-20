var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HistoryListPlayersRoutingModule } from './history-list-players-routing.module';
import { HistoryListPlayersComponent } from './history-list-players.component';
var HistoryListPlayersModule = /** @class */ (function () {
    function HistoryListPlayersModule() {
    }
    HistoryListPlayersModule = __decorate([
        NgModule({
            imports: [
                CommonModule,
                HistoryListPlayersRoutingModule
            ],
            declarations: [HistoryListPlayersComponent]
        })
    ], HistoryListPlayersModule);
    return HistoryListPlayersModule;
}());
export { HistoryListPlayersModule };
//# sourceMappingURL=history-list-players.module.js.map