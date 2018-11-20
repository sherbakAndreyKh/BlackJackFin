import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HistoryPlayerListComponent } from './history-player-list.component';

const routes: Routes = [
    { path: '', component: HistoryPlayerListComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HistoryPlayerListRoutingModule { }
