import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { WindowModule } from '@progress/kendo-angular-dialog';
import { HttpClientModule } from '@angular/common/http';
import { ButtonsModule } from '@progress/kendo-angular-buttons';

@NgModule({
    imports: [
        CommonModule,
        WindowModule,
        HttpClientModule,
        ButtonsModule
    ],
    declarations: []
})
export class HistoryRoundDetailsModalModule { }
