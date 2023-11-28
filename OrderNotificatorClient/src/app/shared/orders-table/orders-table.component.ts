import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { OrderService } from '../service/order.service';
import { MatIconModule } from '@angular/material/icon';
import { ComponentType } from '@angular/cdk/portal';
import { TimerComponent } from '../timer/timer.component';
import { TimeSelectorComponent } from '../time-selector/time-selector.component';

export interface Order {
  id: number;
  number: number;
  tableNumber: string;
  containPizza: boolean;
}

@Component({
  selector: 'orders-table',
  templateUrl: './orders-table.component.html',
  styleUrl: './orders-table.component.css',
  standalone: true,
  imports: [MatTableModule, MatIconModule, TimeSelectorComponent, CommonModule],
})


export class OrdersTableComponent {

  @Input() orders: Order[] = [];

  @Input() type: boolean = true;

  
  displayedColumns: string[] = ['id', 'number', 'tableNumber', 'additionalColumn1', 'additionalColumn2', 'delete'];

  constructor(private orderService: OrderService) {}

  ngOnInit() {
    this.refreshOrders();
  }

  refreshOrders() {
    this.orderService.getOrders().subscribe(
      (apiOrders: any[]) => {
        this.orders = apiOrders.map((apiOrder) => {
          return {
            id: apiOrder.Id.toString(),
            number: apiOrder.Number,
            tableNumber: apiOrder.Table?.Name,
            containPizza: true
          } as Order;
        });
      },
      (error) => {
        console.error('Error fetching orders:', error);
      }
    );
  }

  delete(id: number) {
    this.orders = this.orders.filter((u) => u.id !== id);
  }
}
