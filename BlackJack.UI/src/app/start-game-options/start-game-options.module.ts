import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StartGameOptionsComponent } from './start-game-options.component';
import { AppRoutingModule } from '../app-routing.module';

@NgModule({
  imports: [
    CommonModule, AppRoutingModule 
  ],
    declarations: [StartGameOptionsComponent],
    providers: []
})
export class StartGameOptionsModule {
}
