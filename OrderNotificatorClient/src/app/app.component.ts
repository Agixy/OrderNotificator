import { Component } from '@angular/core';

import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  readonly APIUrl="http://localhost:50789/Order";

  constructor(private http:HttpClient){
  }
  orders:any=[];

  refreshOrders(){
    this.http.get(this.APIUrl).subscribe(data=>{
      this.orders=data;
    })
  }

  ngOnInit(){
    this.refreshOrders();
  }
}