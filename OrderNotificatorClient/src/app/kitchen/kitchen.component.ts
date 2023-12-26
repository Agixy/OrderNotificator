import { Component, OnInit } from '@angular/core';
import { Order, OrderService } from '../shared/service/order.service';
import { OrdersTableComponent } from '../shared/orders-table/orders-table.component';
import { ServingPlaceType } from '../shared/enums/ServingPlaceType';

@Component({
  selector: 'app-kitchen',
  templateUrl: './kitchen.component.html',
  styleUrl: './kitchen.component.css',
  standalone: true,
  imports: [OrdersTableComponent],
})

export class KitchenComponent {
  orders: Order[] = [];
  type: ServingPlaceType = ServingPlaceType.Kitchen;
}