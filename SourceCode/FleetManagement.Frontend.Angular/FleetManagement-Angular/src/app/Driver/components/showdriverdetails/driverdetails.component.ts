import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  isVisible = true;

  constructor(
    private driverService: DriverService,
    private router: Router) { }

  async getDriverDetails(id: number): Promise<void>{ 
    this.sub = await this.driverService.GetDriverDetails(1).subscribe({
      next: driver => this.driverDetails = driver,
      error: error => this.errorMessage = error
    });
  }

  goToUpdateContactInfo(){
    this.isVisible = !this.isVisible;
    this.router.navigate(['/updatecontactinfo'])
  }
  
  ngOnInit(): void {
    const id = 1; //how will the id be decided? 
    this.getDriverDetails(id);
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}