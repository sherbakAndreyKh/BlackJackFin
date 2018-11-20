import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WelcomeScreenComponent } from 'src/app/welcome-screen/welcome-screen.component';

const routes: Routes = [
    { path: '', component: WelcomeScreenComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class WelcomeScreenRoutingModule { }
