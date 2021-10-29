import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IDriverDetails } from '../../models/read/idriver-details';
import { DriverService } from '../../services/driver.service';

@Component({
  selector: 'fm-driverdetails',
  templateUrl: './driverdetails.component.html',
  styleUrls: ['./driverdetails.component.css']
})
export class Driverdetailscomponent implements OnInit {

  pageTitle = 'DriverDetails';
  driverDetails: IDriverDetails | undefined;
  errorMessage = '';
  sub!: Subscription; //defnite assignment assertion?

  constructor(private driverService: DriverService) { }

  ngOnInit(): void {
    const id = 1; //how will the id be decided? 
    this.getProduct(id);
  }

  getProduct(id: number): void{ 
    this.sub = this.driverService.GetDriverDetails(1).subscribe({
      next: driver => { this.driverDetails = driver; },
      error: error => this.errorMessage = error
    });
  }
  
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}