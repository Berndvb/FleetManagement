import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IFuelCard } from '../../models/read/ifuel-card';
import { IResponse } from '../../models/standardresponse/iresponse';
import { DriverService } from '../../services/driver.service';

@Component({
  selector: 'fm-fuelcardinfo',
  templateUrl: './fuelcardinfo.component.html',
  styleUrls: ['./fuelcardinfo.component.css']
})
export class FuelcardinfoComponent implements OnInit {

  pageTitle = 'GetFuelCardInfo';
  fuelCardInfo: IResponse<IFuelCard> | undefined;
  errorMessage = '';
  sub!: Subscription; 

  constructor(private driverService: DriverService) { }

  ngOnInit(): void {
    const id = 1; 
    this.getFuelCards(id);
  }

  getFuelCards(id: number): void{ 
    this.sub = this.driverService.GetFuelCardsForDriver(1).subscribe({
      next: x => { this.fuelCardInfo = x },
      error: error => this.errorMessage = error
    });
  }
  
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
