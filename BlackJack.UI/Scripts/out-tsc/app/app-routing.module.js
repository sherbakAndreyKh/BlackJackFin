var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
var routes = [
    { path: '', redirectTo: '/welcome', pathMatch: 'full' },
    {
        path: 'welcome',
        loadChildren: './hello-screen/hello-screen.module#HelloScreenModule'
    },
    {
        path: 'startOptions',
        loadChildren: './start-game-options/start-game-options.module#StartGameOptionsModule'
    },
    {
        path: 'gameProcess',
        loadChildren: './game-process/game-process.module#GameProcessModule'
    },
    {
        path: 'playerList',
        loadChildren: './history-list-players/history-list-players.module#HistoryListPlayersModule'
    },
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        NgModule({
            exports: [
                RouterModule
            ],
            imports: [
                RouterModule.forRoot(routes)
            ],
            declarations: []
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
export { AppRoutingModule };
//# sourceMappingURL=app-routing.module.js.map