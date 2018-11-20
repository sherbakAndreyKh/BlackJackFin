import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WelcomeScreenRoutingModule } from 'src/app/welcome-screen/welcome-screen-routing.module';
import { WelcomeScreenComponent } from 'src/app/welcome-screen/welcome-screen.component';

@NgModule({
    imports: [
        CommonModule,
        WelcomeScreenRoutingModule
    ],
    declarations: [WelcomeScreenComponent]
})
export class WelcomeScreenModule { }
