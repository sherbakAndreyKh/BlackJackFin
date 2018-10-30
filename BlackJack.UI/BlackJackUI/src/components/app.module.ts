import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { WelcomeScreenComponent} from './welcomeScreen/welcomeScreen.component';
import { StartGameOptionsComponent} from './startGameOptions/startGameOptions.component';
import { AppRoutingModule } from './app-routing.module';
import { GameProcessComponent } from './gameProcessComponent/gameProcess.component';

@NgModule({
  declarations: [
    AppComponent, 
    WelcomeScreenComponent,
    StartGameOptionsComponent,
    GameProcessComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
