import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';

export interface Order {
  id: number;
  number: number;
  tableNumber: string;
  containPizza: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private readonly APIUrl = "http://localhost:50789/Order";

  constructor(private http: HttpClient) { }

  getOrders(): Observable<Order[]> {
    return this.http.get<any[]>(this.APIUrl).pipe(
      map((apiOrders: any[]) => this.mapToOrders(apiOrders))
    );
  }

  getNewOrders(lastId: number): Observable<Order[]> {
    return this.http.post<any[]>(`${this.APIUrl}/`, { lastId }).pipe(
      map((newApiOrders: any[]) => this.mapToOrders(newApiOrders))
    );
  }

  private mapToOrders(apiOrders: any[]): Order[] {
    return apiOrders.map((apiOrder) => {
      return {
        id: apiOrder.Id.toString(),
        number: apiOrder.Number,
        tableNumber: apiOrder.Table?.Name,
        containPizza: true,
      } as Order;
    });
  }
}
