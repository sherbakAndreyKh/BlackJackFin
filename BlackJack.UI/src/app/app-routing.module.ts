import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StartGameOptionsComponent } from './start-game-options/start-game-options.component';
import { WelcomeScreenComponent } from './welcomeScreen/welcomeScreen.component';
import { GameProcessComponent } from './game-process/game-process.component';



const routes: Routes =[
    { path: '', redirectTo: 'welcome', pathMatch: 'full' },
    { path: 'welcome', component: WelcomeScreenComponent },
    { path: 'startOptions',
     loadChildren: './start-game-options/start-game-options.module#StartGameOptionsModule' },
    {path: 'gameProcess', component: GameProcessComponent}, 
];

@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule]
})

export class AppRoutingModule{}