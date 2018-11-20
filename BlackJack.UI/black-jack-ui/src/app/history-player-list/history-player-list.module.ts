import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid';

import { HistoryPlayerListRoutingModule } from 'src/app/history-player-list/history-player-list-routing.module';
import { HistoryPlayerListComponent } from 'src/app/history-player-list/history-player-list.component';


@NgModule({
    imports: [
        CommonModule,
        HistoryPlayerListRoutingModule,
        HttpClientModule,
        GridModule
    ],

    declarations: [HistoryPlayerListComponent]
})
export class HistoryPlayerListModule { }
