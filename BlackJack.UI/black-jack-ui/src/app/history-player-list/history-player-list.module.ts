import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HistoryPlayerListRoutingModule } from './history-player-list-routing.module';
import { HistoryPlayerListComponent } from './history-player-list.component';

@NgModule({
  imports: [
    CommonModule,
    HistoryPlayerListRoutingModule
  ],
  declarations: [HistoryPlayerListComponent]
})
export class HistoryPlayerListModule { }
