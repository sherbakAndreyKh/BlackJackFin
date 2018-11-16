import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HistoryPlayerGamesListRoutingModule } from './history-player-games-list-routing.module';
import { HistoryPlayerGamesListComponent } from './history-player-games-list.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,
    HistoryPlayerGamesListRoutingModule,
    HttpClientModule
  ],
  declarations: [HistoryPlayerGamesListComponent]
})
export class HistoryPlayerGamesListModule { }
