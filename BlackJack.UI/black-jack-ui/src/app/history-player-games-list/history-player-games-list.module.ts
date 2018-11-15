import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HistoryPlayerGamesListRoutingModule } from './history-player-games-list-routing.module';
import { HistoryPlayerGamesListComponent } from './history-player-games-list.component';

@NgModule({
  imports: [
    CommonModule,
    HistoryPlayerGamesListRoutingModule
  ],
  declarations: [HistoryPlayerGamesListComponent]
})
export class HistoryPlayerGamesListModule { }
