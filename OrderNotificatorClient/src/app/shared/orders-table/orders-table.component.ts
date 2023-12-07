import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { Order, OrderService } from '../service/order.service';
import { MatIconModule } from '@angular/material/icon';
import { TimeSelectorComponent } from '../time-selector/time-selector.component';
import { Subscription, interval, switchMap } from 'rxjs';
import { TimerComponent } from '../timer/timer.component';
import { ServingPlaceType } from '../enums/ServingPlaceType';

@Component({
  selector: 'orders-table',
  templateUrl: './orders-table.component.html',
  styleUrl: './orders-table.component.css',
  standalone: true,
  imports: [MatTableModule, MatIconModule, TimeSelectorComponent, TimerComponent, CommonModule],
})

export class OrdersTableComponent {

  @Input() orders: Order[] = [];
  @Input() type: ServingPlaceType = ServingPlaceType.Kitchen;

  private subscription: Subscription = new Subscription;
  
  displayedColumns: string[] = ['number', 'tableNumber', 'additionalColumn1', 'timer', 'delete'];

  constructor(private orderService: OrderService) {}

  ngOnInit() {
    this.refreshOrders();

    this.subscription = interval(10000)
    .pipe(
      switchMap(() => this.orderService.getNewOrders(this.orders.length > 0 ? this.orders[0].id : 0))
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

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  refreshOrders() {
    this.orderService.getOrders().subscribe(
      (apiOrders: Order[]) => {
        this.orders = apiOrders;
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
