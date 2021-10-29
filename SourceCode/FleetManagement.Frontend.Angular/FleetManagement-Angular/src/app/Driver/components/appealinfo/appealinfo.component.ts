import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IAppeal } from '../../models/read/iappeal';
import { IResponse } from '../../models/standardresponse/iresponse';
import { DriverService } from '../../services/driver.service';


@Component({
  selector: 'fm-appealinfo',
  templateUrl: './appealinfo.component.html',
  styleUrls: ['./appealinfo.component.css']
})
export class AppealinfoComponent implements OnInit {

  pageTitle = 'Appealinfo';
  appealInfo: IResponse<IAppeal> | undefined;
  errorMessage = '';
  sub!: Subscription; 

  constructor(private driverService: DriverService) { }

  ngOnInit(): void {
    const id = 1; 
    this.getAppeals(id);
  }

  getAppeals(id: number): void{ 
    this.sub = this.driverService.GetAppealsForDriver(1).subscribe({
      next: x => { this.appealInfo = x },
      error: error => this.errorMessage = error
    });
  }
  
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
