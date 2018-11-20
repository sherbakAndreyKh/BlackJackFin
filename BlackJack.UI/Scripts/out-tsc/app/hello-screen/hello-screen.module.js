var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HelloScreenRoutingModule } from './hello-screen-routing.module';
import { HelloScreenComponent } from './hello-screen.component';
var HelloScreenModule = /** @class */ (function () {
    function HelloScreenModule() {
    }
    HelloScreenModule = __decorate([
        NgModule({
            imports: [
                CommonModule,
                HelloScreenRoutingModule
            ],
            declarations: [HelloScreenComponent]
        })
    ], HelloScreenModule);
    return HelloScreenModule;
}());
export { HelloScreenModule };
//# sourceMappingURL=hello-screen.module.js.map