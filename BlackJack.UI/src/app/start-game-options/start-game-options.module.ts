import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StartGameOptionsRoutingModule } from './start-game-options-routing.module';
import { StartGameOptionsComponent } from './start-game-options.component';

@NgModule({
  imports: [
    CommonModule,
    StartGameOptionsRoutingModule
  ],
  declarations: [StartGameOptionsComponent]
})
export class StartGameOptionsModule { }
