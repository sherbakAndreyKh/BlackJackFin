import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid';

import { HistoryPlayerGamesListRoutingModule } from 'src/app/history-player-games-list/history-player-games-list-routing.module';
import { HistoryPlayerGamesListComponent } from 'src/app/history-player-games-list/history-player-games-list.component';

@NgModule({
    imports: [
        CommonModule,
        HistoryPlayerGamesListRoutingModule,
        HttpClientModule,
        GridModule
    ],
    declarations: [HistoryPlayerGamesListComponent]
})
export class HistoryPlayerGamesListModule { }
