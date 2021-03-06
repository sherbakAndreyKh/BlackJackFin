import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StartGameOptionsComponent } from 'src/app/start-game-options/start-game-options.component';

const routes: Routes = [
  {path:'', component: StartGameOptionsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StartGameOptionsRoutingModule { }
