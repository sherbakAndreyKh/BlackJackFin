import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HistoryPlayerListRoutingModule } from './history-player-list-routing.module';
import { HistoryPlayerListComponent } from './history-player-list.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GridModule } from '@progress/kendo-angular-grid'; 


@NgModule({
  imports: [
    CommonModule,
    HistoryPlayerListRoutingModule,
    HttpClientModule,
    GridModule
  ],

  declarations: [HistoryPlayerListComponent]
})
export class HistoryPlayerListModule { }
