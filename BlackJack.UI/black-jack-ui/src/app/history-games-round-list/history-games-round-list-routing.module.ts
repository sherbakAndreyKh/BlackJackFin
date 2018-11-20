import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HistoryGamesRoundListComponent } from 'src/app/history-games-round-list/history-games-round-list.component';

const routes: Routes = [
    { path: '', component: HistoryGamesRoundListComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HistoryGamesRoundListRoutingModule { }
