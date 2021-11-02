import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup  } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Appealtype } from '../../models/enums/appealtype';
import { ICreateAppeal } from '../../models/write/icreate-appeal';
import { IUpdateAppealInfo } from '../../models/write/iupdate-appeal-info';
import { DriverService } from '../../services/driver.service';


@Component({
  selector: 'fm-updateappealinfo',
  templateUrl: './updateappealinfo.component.html',
  styleUrls: ['./updateappealinfo.component.css']
})
export class UpdateappealinfoComponent implements OnInit {

  updateAppealForm = new FormGroup({
    appealType : new FormControl(''),
    firstDatePlanning : new FormControl(null),
    secondDatePlanning : new FormControl(null),
    message : new FormControl('')});
  
    appealId = 2;
    appealtype = Appealtype;
    
    sub!: Subscription;
    response: any;
    errorMessage = '';
  
    constructor(private driverService: DriverService) { }
  
    onSubmit(body: IUpdateAppealInfo): void{
      this.sub = this.driverService.UpdateAppealInfo(this.appealId, body).subscribe({
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
