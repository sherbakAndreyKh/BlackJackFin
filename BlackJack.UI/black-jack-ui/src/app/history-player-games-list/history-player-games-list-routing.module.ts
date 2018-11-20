import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HistoryPlayerGamesListComponent } from './history-player-games-list.component';

const routes: Routes = [
  {path: '', component: HistoryPlayerGamesListComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HistoryPlayerGamesListRoutingModule { }
