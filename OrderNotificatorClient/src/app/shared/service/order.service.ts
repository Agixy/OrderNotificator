import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { OrderContent } from '../enums/OrderContent';

export class Order {
  id!: number;
  posId!: number;
  number!: number;
  tableName!: string;
  orderContent!: OrderContent;
  deliveryTime!: Date;
}

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private readonly APIUrl = "http://localhost:50789/Order";

  constructor(private http: HttpClient) { }

  getKitchenOrders(lastId: number): Observable<Order[]> {
    return this.http.get<any[]>(`${this.APIUrl}/Kitchen/${lastId}`).pipe(
      map((apiOrders: any[]) => this.mapToOrders(apiOrders))
    );
  }

  getPizzaOrders(lastId: number): Observable<Order[]> {
    return this.http.get<any[]>(`${this.APIUrl}/Pizza/${lastId}`).pipe(
      map((apiOrders: any[]) => this.mapToOrders(apiOrders))
    );
  }

  private mapToOrders(apiOrders: any[]): Order[] {
    return apiOrders.map((apiOrder) => {
      return {
        id: apiOrder.TimedOrderId.toString(),
        posId: apiOrder.PosId.toString(),
        number: apiOrder.Number,
        tableName: apiOrder.TableName,
        orderContent: OrderContent.PizzaAndDishes, // TODO: get data from database
        deliveryTime: new Date(apiOrder.DeliveryTime)
      } as Order;
    });
  }

  addPizzaDeliveryTime(order: Order): Observable<Order>{
    return this.http.post<Order>(`${this.APIUrl}/PizzaDeliveryTime`, order);
  }
}
