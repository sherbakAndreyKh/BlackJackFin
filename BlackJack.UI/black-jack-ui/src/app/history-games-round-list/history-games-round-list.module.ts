import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HistoryGamesRoundListRoutingModule } from './history-games-round-list-routing.module';
import { HistoryGamesRoundListComponent } from './history-games-round-list.component';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid'; 
import { WindowModule } from '@progress/kendo-angular-dialog';
import { HistoryRoundDetailsModalComponent } from '../history-round-details-modal/history-round-details-modal.component';
import { ButtonsModule } from '@progress/kendo-angular-buttons';

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
