import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Subscription } from 'rxjs';
import { IUpdateFuelCardInfo } from '../../models/write/iupdate-fuel-card-info';
import { DriverService } from '../../services/driver.service';
import { AuthenticationType } from '../../models/enums/authentication-type';

@Component({
  selector: 'fm-updatefuelcardinfo',
  templateUrl: './updatefuelcardinfo.component.html',
  styleUrls: ['./updatefuelcardinfo.component.css']
})
export class UpdatefuelcardinfoComponent implements OnInit {

  updateFuelCardForm = new FormGroup({
    pincode : new FormControl(''),
    authenticationType : new FormControl(AuthenticationType.Pin),
    blocked : new FormControl(false)});
  
    fuelCardId = 1;
    authenticationType = AuthenticationType;
    
    sub!: Subscription;
    response: any;
    errorMessage = '';
  
    constructor(private driverService: DriverService) { }
  
    onSubmit(body: IUpdateFuelCardInfo): void{
      this.sub = this.driverService.UpdateFuelCardInfo(this.fuelCardId, body).subscribe({
        next: createResponse => this.response = createResponse,
        error: error => this.errorMessage = error
      })
    }

    ngOnInit(): void {
    }

    ngOnDestroy(): void {
      this.sub.unsubscribe();
    }

}
