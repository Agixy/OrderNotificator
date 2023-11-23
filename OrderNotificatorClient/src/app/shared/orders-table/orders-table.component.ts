import { Component, Input } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { OrderService } from '../service/order.service';
import { MatIconModule } from '@angular/material/icon';

export interface Order {
  id: number;
  number: number;
  tableNumber: string;
}

@Component({
  selector: 'orders-table',
  templateUrl: './orders-table.component.html',
  styleUrl: './orders-table.component.css',
  standalone: true,
  imports: [MatTableModule, MatIconModule],
})


export class OrdersTableComponent {

  @Input() orders: Order[] = [];
  
  displayedColumns: string[] = ['id', 'number', 'tableNumber', 'delete'];

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
            tableNumber: apiOrder.Table?.Name
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
