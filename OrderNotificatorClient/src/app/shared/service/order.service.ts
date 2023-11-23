import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../orders-table/orders-table.component';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private readonly APIUrl = "http://localhost:50789/Order";

  constructor(private http: HttpClient) { }

  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(this.APIUrl);
  }
}
