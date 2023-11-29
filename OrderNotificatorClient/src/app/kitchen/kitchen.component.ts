import { Component, OnInit } from '@angular/core';
import { Order, OrderService } from '../shared/service/order.service';
import { OrdersTableComponent } from '../shared/orders-table/orders-table.component';
import { TimerComponent } from '../shared/timer/timer.component';

@Component({
  selector: 'app-kitchen',
  templateUrl: './kitchen.component.html',
  styleUrl: './kitchen.component.css',
  standalone: true,
  imports: [OrdersTableComponent, TimerComponent],
})

export class KitchenComponent implements OnInit {
  orders: Order[] = [];

  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.orderService.getOrders().subscribe(data => {
      this.orders = data;
    });
  }
}