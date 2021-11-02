import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IVehicleDetails } from '../../models/read/ivehicle-details';
import { IResponse } from '../../models/standardresponse/iresponse';
import { DriverService } from '../../services/driver.service';

@Component({
  selector: 'fm-vehicleinfo',
  templateUrl: './vehicleinfo.component.html',
  styleUrls: ['./vehicleinfo.component.css']
})
export class VehicleinfoComponent implements OnInit {

  pageTitle = 'vehicleInfo';
  vehicleInfo: IResponse<IVehicleDetails> | undefined;
  errorMessage = '';
  sub!: Subscription; 

  constructor(private driverService: DriverService) { }

  ngOnInit(): void {
    const id = 1; 
    this.getVehicles(id);
  }

  getVehicles(id: number): void{ 
    this.sub = this.driverService.GetVehiclesForDriver(1).subscribe({
      next: x => { this.vehicleInfo = x },
      error: error => this.errorMessage = error
    });
  }
  
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
