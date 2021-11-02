import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DriverService } from '../../services/driver.service';
import { ICreateAppeal } from '../../models/write/icreate-appeal';
import { Subscription } from 'rxjs';
import { Appealtype } from '../../models/appealtype';


@Component({
  selector: 'fm-createappeal',
  templateUrl: './createappeal.component.html',
  styleUrls: ['./createappeal.component.css']
})
export class CreateappealComponent implements OnInit {

  createAppealForm = new FormGroup({
  appealType : new FormControl(''),
  firstDatePlanning : new FormControl(null),
  secondDatePlanning : new FormControl(null),
  incidentDate : new FormControl(null),
  damageDescription : new FormControl(''),
  vehicleLocation : new FormControl(''),
  message : new FormControl('')});

  status!: string;
  vehicleId!: number;
  driverId!: number;
  creationDate!: Date;
  
  sub!: Subscription;
  response: any;
  errorMessage = '';

  appealtype = Appealtype;

  constructor(private driverService: DriverService) { }

  onSubmit(body: ICreateAppeal): void{
    this.createAppeal(this.SetAppealInfo(body));
  }

  SetAppealInfo(body: ICreateAppeal): ICreateAppeal {
    body.status = 'New';
    body.vehicleId = 1;
    body.driverId = 1;
    body.creationDate = new Date();
    return body;
  }

  createAppeal(body: ICreateAppeal): void{
    this.sub = this.driverService.CreateAppeal(body).subscribe({
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
