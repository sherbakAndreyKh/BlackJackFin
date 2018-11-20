var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HistoryGamesRoundListRoutingModule } from './history-games-round-list-routing.module';
import { HistoryGamesRoundListComponent } from './history-games-round-list.component';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid';
import { WindowModule } from '@progress/kendo-angular-dialog';
import { HistoryRoundDetailsModalComponent } from '../history-round-details-modal/history-round-details-modal.component';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
var HistoryGamesRoundListModule = /** @class */ (function () {
    function HistoryGamesRoundListModule() {
    }
    HistoryGamesRoundListModule = __decorate([
        NgModule({
            imports: [
                CommonModule,
                HistoryGamesRoundListRoutingModule,
                HttpClientModule,
                GridModule,
                WindowModule,
                ButtonsModule,
            ],
            declarations: [
                HistoryGamesRoundListComponent,
                HistoryRoundDetailsModalComponent
            ]
        })
    ], HistoryGamesRoundListModule);
    return HistoryGamesRoundListModule;
}());
export { HistoryGamesRoundListModule };
//# sourceMappingURL=history-games-round-list.module.js.map