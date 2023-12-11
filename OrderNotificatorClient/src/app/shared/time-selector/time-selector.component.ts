import { Component } from '@angular/core';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { OrderService } from '../service/order.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'time-selector',
  templateUrl: './time-selector.component.html',
  styleUrl: './time-selector.component.css',
  standalone: true,
  imports: [MatButtonToggleModule],
})
export class TimeSelectorComponent {

  private subscription: Subscription = new Subscription();

  constructor(private orderService: OrderService){}

  ngOnInit(){

  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }   
  }

  setPizzaDeliveryTime(time: number) : Date{
    let time_ = parseInt(time.toString());
    let currentDate = new Date();
    currentDate.setMinutes(currentDate.getMinutes() + time_);
    return currentDate;
  }

  deliveryTimeSelected(event : any){    
    let selectedTime : number = event.value;
    let pizzaDeliveryTime = this.setPizzaDeliveryTime(selectedTime);
    this.addPizzaDeliveryTime(pizzaDeliveryTime);
  }

  addPizzaDeliveryTime(time: Date){
    this.orderService
    .addPizzaDeliveryTime(time)
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
