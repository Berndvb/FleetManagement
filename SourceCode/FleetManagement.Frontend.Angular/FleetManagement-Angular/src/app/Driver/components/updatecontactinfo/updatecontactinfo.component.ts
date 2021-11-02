import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthenticationType } from '../../models/enums/authentication-type';
import { IUpdateContactInfo } from '../../models/write/iupdate-contact-info';
import { DriverService } from '../../services/driver.service';

@Component({
  selector: 'fm-updatecontactinfo',
  templateUrl: './updatecontactinfo.component.html',
  styleUrls: ['./updatecontactinfo.component.css']
})
export class UpdatecontactinfoComponent implements OnInit {

  updateContactInfoForm = new FormGroup({
    emailAddress : new FormControl(''),
    phoneNumber : new FormControl(''),
    street : new FormControl(''),
    streetNumber : new FormControl(''),
    city : new FormControl(''),
    postcode : new FormControl('')});
    
    driverId = 1;
    
    sub!: Subscription;
    response: any;
    errorMessage = '';
  
    constructor(
      private driverService: DriverService,
      private router: Router) { }
  
    onSubmit(body: IUpdateContactInfo): void{
      this.sub = this.driverService.UpdateContactInfo(this.driverId, body).subscribe({
        next: createResponse => this.response = createResponse,
        error: error => this.errorMessage = error,
      }),
      this.router.navigate(['/showdriverdetails'])
    }

    ngOnInit(): void {
    }

    ngOnDestroy(): void {
      this.sub.unsubscribe();
    }

}
