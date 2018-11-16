var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HistoryPlayerListRoutingModule } from './history-player-list-routing.module';
import { HistoryPlayerListComponent } from './history-player-list.component';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid';
var HistoryPlayerListModule = /** @class */ (function () {
    function HistoryPlayerListModule() {
    }
    HistoryPlayerListModule = __decorate([
        NgModule({
            imports: [
                CommonModule,
                HistoryPlayerListRoutingModule,
                HttpClientModule,
                GridModule
            ],
            declarations: [HistoryPlayerListComponent]
        })
    ], HistoryPlayerListModule);
    return HistoryPlayerListModule;
}());
export { HistoryPlayerListModule };
//# sourceMappingURL=history-player-list.module.js.map