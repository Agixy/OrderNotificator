import { Component, OnInit } from '@angular/core';
import { Order, OrderService } from '../shared/service/order.service';
import { OrdersTableComponent } from '../shared/orders-table/orders-table.component';
import { ServingPlaceType } from '../shared/enums/ServingPlaceType';

@Component({
  selector: 'app-pizza',
  templateUrl: './pizza.component.html',
  styleUrl: './pizza.component.css',
  standalone: true,
  imports: [OrdersTableComponent],
})
export class PizzaComponent implements OnInit {
  orders: Order[] = [];
  type: ServingPlaceType = ServingPlaceType.Pizza;

  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.orderService.getPizzaOrders(0).subscribe(data => {
      this.orders = data;
    });
  }

}
