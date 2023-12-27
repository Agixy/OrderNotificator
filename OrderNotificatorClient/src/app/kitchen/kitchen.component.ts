import { Component, OnInit } from '@angular/core';
import { Order, OrderService } from '../shared/service/order.service';
import { OrdersTableComponent } from '../shared/orders-table/orders-table.component';
import { ServingPlaceType } from '../shared/enums/ServingPlaceType';
import { Subscription, switchMap, timer } from 'rxjs';

@Component({
  selector: 'app-kitchen',
  templateUrl: './kitchen.component.html',
  styleUrl: './kitchen.component.css',
  standalone: true,
  imports: [OrdersTableComponent],
})

export class KitchenComponent implements OnInit {
  orders: Order[] = [];
  type: ServingPlaceType = ServingPlaceType.Kitchen;

  private subscription: Subscription = new Subscription;

  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.subscription = timer(0, 10000)
    .pipe(
      switchMap(() => this.orderService.getKitchenOrders(this.orders.length > 0 ? this.orders[this.orders.length-1].posId : 0))
    )
    .subscribe(
      (newOrders: Order[]) => {
        this.orders = [...this.orders, ...newOrders];
      },
      (error) => {
        console.error('Error fetching new orders:', error);
      }
    );
  }
}