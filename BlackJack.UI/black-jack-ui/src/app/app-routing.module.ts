import { NgModule } from '@angular/core';
import { Routes, RouterModule} from '@angular/router';

const routes:Routes =[
  {path: '', redirectTo: 'welcome', pathMatch:'full'},
  {path: 'welcome', loadChildren: './welcome-screen/welcome-screen.module#WelcomeScreenModule'},
  {path: 'startOptions', loadChildren: './start-game-options/start-game-options.module#StartGameOptionsModule'},
  {path: 'gameProcess', loadChildren: './game-process/game-process.module#GameProcessModule'},
  {path: 'history', loadChildren: './history-player-list/history-player-list.module#HistoryPlayerListModule'}
]


@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class AppRoutingModule { }
