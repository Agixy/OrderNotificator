import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { KitchenComponent } from './kitchen/kitchen.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OrdersTableComponent } from './shared/orders-table/orders-table.component';
import { TimerComponent } from './shared/timer/timer.component';
import { TimeSelectorComponent } from './shared/time-selector/time-selector.component';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    KitchenComponent,
    OrdersTableComponent,
    TimerComponent,
    TimeSelectorComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }