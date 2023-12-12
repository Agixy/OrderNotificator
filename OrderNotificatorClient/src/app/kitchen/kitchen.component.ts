import { Component, OnInit } from '@angular/core';
import { Order, OrderService } from '../shared/service/order.service';
import { OrdersTableComponent } from '../shared/orders-table/orders-table.component';
import { TimerComponent } from '../shared/timer/timer.component';
import { ServingPlaceType } from '../shared/enums/ServingPlaceType';

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

  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.orderService.getKitchenOrders(0).subscribe(data => {
      this.orders = data;
    });
  }
}