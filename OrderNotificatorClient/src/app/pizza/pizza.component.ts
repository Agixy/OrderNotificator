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
export class PizzaComponent {
  orders: Order[] = [];
  type: ServingPlaceType = ServingPlaceType.Pizza;
}
