import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {GameProcessComponent} from 'src/app/game-process/game-process.component';

const routes: Routes = [
    { path: '', component: GameProcessComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class GameProcessRoutingModule { }
