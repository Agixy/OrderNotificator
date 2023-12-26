import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { Order, OrderService } from '../service/order.service';
import { MatIconModule } from '@angular/material/icon';
import { TimeSelectorComponent } from '../time-selector/time-selector.component';
import { Subscription, switchMap, timer } from 'rxjs';
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
  private timerSubscription: Subscription = new Subscription;
  
  displayedColumns: string[] = ['number', 'tableName', 'timeSelector', 'timer', 'delete'];

  constructor(private orderService: OrderService) {}

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

    this.timerSubscription = timer(0, 15000)
    .pipe(
      switchMap(() => this.orderService.getTimedOrders())
    )
    .subscribe(
      (timedOrders: Order[]) => {
        timedOrders.forEach(timedOrder => {
          var index = this.orders.findIndex(o => o.posId === timedOrder.posId);
          if (index > -1) {
            this.orders[index].deliveryTime = timedOrder.deliveryTime;
          }
        });
      }
    );
  }
   
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  delete(id: number) {
    this.orders = this.orders.filter((u) => u.posId !== id);  
  }
}
