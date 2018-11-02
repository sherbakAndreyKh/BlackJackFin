"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var start_game_options_component_1 = require("./start-game-options.component");
var app_routing_module_1 = require("../app-routing.module");
var StartGameOptionsModule = /** @class */ (function () {
    function StartGameOptionsModule() {
    }
    StartGameOptionsModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule, app_routing_module_1.AppRoutingModule
            ],
            declarations: [start_game_options_component_1.StartGameOptionsComponent],
            providers: []
        })
    ], StartGameOptionsModule);
    return StartGameOptionsModule;
}());
exports.StartGameOptionsModule = StartGameOptionsModule;
//# sourceMappingURL=start-game-options.module.js.map