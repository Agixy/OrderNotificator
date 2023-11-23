import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { KitchenComponent } from './kitchen/kitchen.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OrdersTableComponent } from './shared/orders-table/orders-table.component';


@NgModule({
  declarations: [
    AppComponent,
    KitchenComponent        
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    OrdersTableComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }