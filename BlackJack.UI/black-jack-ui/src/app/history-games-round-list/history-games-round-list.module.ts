import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid';
import { WindowModule } from '@progress/kendo-angular-dialog';
import { ButtonsModule } from '@progress/kendo-angular-buttons';

import { HistoryGamesRoundListComponent } from 'src/app/history-games-round-list/history-games-round-list.component';
import { HistoryGamesRoundListRoutingModule } from 'src/app/history-games-round-list/history-games-round-list-routing.module';
import { HistoryRoundDetailsModalComponent } from 'src/app/history-round-details-modal/history-round-details-modal.component';

@NgModule({
    imports: [
        CommonModule,
        HistoryGamesRoundListRoutingModule,
        HttpClientModule,
        GridModule,
        WindowModule,
        ButtonsModule,
    ],
    declarations: [
        HistoryGamesRoundListComponent,
        HistoryRoundDetailsModalComponent
    ]
})
export class HistoryGamesRoundListModule { }
