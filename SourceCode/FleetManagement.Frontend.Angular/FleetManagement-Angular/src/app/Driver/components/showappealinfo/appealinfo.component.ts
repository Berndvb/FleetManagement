import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  driverId = 1;
  errorMessage = '';
  sub!: Subscription; 
  isVisible = true;

  constructor(
    private driverService: DriverService,
    private router: Router) { }

  getAppeals(id: number): void{ 
    this.sub = this.driverService.GetAppealsForDriver(this.driverId).subscribe({
      next: x => { this.appealInfo = x },
      error: error => this.errorMessage = error
    });
  }

  goToUpdateAppealInfo(){
    this.isVisible = !this.isVisible;
    this.router.navigate(['/updateappealinfo'])
  }

  ngOnInit(): void {
    const id = 1; 
    this.getAppeals(id);
  }
  
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
