import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  isVisible = true;

  constructor(
    private driverService: DriverService,
    private router: Router) { }

  getVehicles(id: number): void{ 
    this.sub = this.driverService.GetVehiclesForDriver(1).subscribe({
      next: x => { this.vehicleInfo = x },
      error: error => this.errorMessage = error
    });
  }
  
  goToUpdateVehicleInfo(){
    this.isVisible = !this.isVisible;
    this.router.navigate(['/updatevehicleinfo'])
  }
  
  ngOnInit(): void {
    const id = 1; 
    this.getVehicles(id);
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
