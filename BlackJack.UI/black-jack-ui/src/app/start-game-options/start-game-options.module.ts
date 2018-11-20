import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { WindowModule } from '@progress/kendo-angular-dialog';
import { ButtonsModule } from '@progress/kendo-angular-buttons';

import { StartGameOptionsRoutingModule } from 'src/app/start-game-options/start-game-options-routing.module';
import { StartGameOptionsComponent } from 'src/app/start-game-options/start-game-options.component';
import { GameProcessComponent } from 'src/app/game-process/game-process.component';

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
