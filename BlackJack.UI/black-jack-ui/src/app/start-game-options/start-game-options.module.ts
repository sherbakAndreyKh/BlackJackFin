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

@NgModule({
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
export class StartGameOptionsModule { }
