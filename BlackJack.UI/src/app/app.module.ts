import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { WelcomeScreenComponent } from './welcomeScreen/welcomeScreen.component';
import { StartGameOptionsComponent } from './start-game-options/start-game-options.component';
import { AppRoutingModule } from './app-routing.module';
import { GameProcessComponent } from './game-process/game-process.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent, 
    WelcomeScreenComponent,
    StartGameOptionsComponent,
    GameProcessComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
      HttpClientModule,
      FormsModule
  ],
  providers: [],
  
  bootstrap: [AppComponent]
})
export class AppModule {
  
 }
