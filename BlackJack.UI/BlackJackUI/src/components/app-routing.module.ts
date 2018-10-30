import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StartGameOptionsComponent } from './startGameOptions/startGameOptions.component';
import { WelcomeScreenComponent } from './welcomeScreen/welcomeScreen.component';
import { GameProcessComponent } from './gameProcessComponent/gameProcess.component';


const routes: Routes =[
    {path: '', redirectTo: 'welcome', pathMatch: 'full'},
    {path: 'welcome', component: WelcomeScreenComponent},
    {path: 'startOptions', component: StartGameOptionsComponent},
    {path: 'gameProcess', component: GameProcessComponent},
     
];

@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule]
})

export class AppRoutingModule{}