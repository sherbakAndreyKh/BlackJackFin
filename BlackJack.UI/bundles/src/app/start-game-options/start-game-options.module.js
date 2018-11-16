var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StartGameOptionsRoutingModule } from './start-game-options-routing.module';
import { StartGameOptionsComponent } from './start-game-options.component';
import { FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { WindowModule } from '@progress/kendo-angular-dialog';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { GameProcessComponent } from '../game-process/game-process.component';
import { HttpClientModule } from '@angular/common/http';
var StartGameOptionsModule = /** @class */ (function () {
    function StartGameOptionsModule() {
    }
    StartGameOptionsModule = __decorate([
        NgModule({
            imports: [
                CommonModule,
                StartGameOptionsRoutingModule,
                FormsModule,
                DropDownsModule,
                WindowModule,
                ButtonsModule,
                HttpClientModule
            ],
            declarations: [StartGameOptionsComponent, GameProcessComponent]
        })
    ], StartGameOptionsModule);
    return StartGameOptionsModule;
}());
export { StartGameOptionsModule };
//# sourceMappingURL=start-game-options.module.js.map