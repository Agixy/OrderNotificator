import { Component, Input } from '@angular/core';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { Order, OrderService } from '../service/order.service';
import { Subscription } from 'rxjs';
import { ServingPlaceType, } from '../enums/ServingPlaceType';
import { OrderContent } from '../enums/OrderContent';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'time-selector',
  templateUrl: './time-selector.component.html',
  styleUrl: './time-selector.component.css',
  standalone: true,
  imports: [MatButtonToggleModule, CommonModule],
})
export class TimeSelectorComponent {

  @Input() type: ServingPlaceType = ServingPlaceType.Pizza;
  @Input() content: OrderContent = OrderContent.PizzaAndDishes; 

  servingPlaceType: typeof ServingPlaceType = ServingPlaceType;
  orderContent: typeof OrderContent = OrderContent;

  @Input() order!: Order;
  private subscription: Subscription = new Subscription();

  constructor(private orderService: OrderService){}


  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }   
  }

  private calculatePizzaDeliveryTime(minutesToAdd: number) : Date{
    let time_ = parseInt(minutesToAdd.toString());
    let currentDate = new Date();
    currentDate.setMinutes(currentDate.getMinutes() + time_);
    currentDate.setHours(currentDate.getHours() + 1);
    return currentDate;
  }

  deliveryTimeSelected(event : any){    
    let selectedTime : number = event.value;
    let pizzaDeliveryTime = this.calculatePizzaDeliveryTime(selectedTime);
    this.order.deliveryTime = pizzaDeliveryTime;
    this.addPizzaDeliveryTime(this.order);
  }

  addPizzaDeliveryTime(order: Order){
    this.orderService
    .addPizzaDeliveryTime(order)
    .subscribe(timeAPI =>
      {
          console.log("Czas wydania pizzy został zapisany.");
      },
      (error) => 
      {
        console.log("Błąd podczas zapisywania czasu wydania pizzy.", error)
      });
  }
}
