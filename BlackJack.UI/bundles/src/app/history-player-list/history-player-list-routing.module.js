var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HistoryPlayerListComponent } from 'src/app/history-player-list/history-player-list.component';
var routes = [
    { path: '', component: HistoryPlayerListComponent }
];
var HistoryPlayerListRoutingModule = /** @class */ (function () {
    function HistoryPlayerListRoutingModule() {
    }
    HistoryPlayerListRoutingModule = __decorate([
        NgModule({
            imports: [RouterModule.forChild(routes)],
            exports: [RouterModule]
        })
    ], HistoryPlayerListRoutingModule);
    return HistoryPlayerListRoutingModule;
}());
export { HistoryPlayerListRoutingModule };
//# sourceMappingURL=history-player-list-routing.module.js.map