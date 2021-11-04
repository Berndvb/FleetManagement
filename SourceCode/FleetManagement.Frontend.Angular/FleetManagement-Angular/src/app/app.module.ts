import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppealinfoComponent } from './Driver/components/showappealinfo/appealinfo.component';
import { Driverdetailscomponent } from './Driver/components/showdriverdetails/driverdetails.component';
import { FuelcardinfoComponent } from './Driver/components/showfuelcardinfo/fuelcardinfo.component';
import { VehicleinfoComponent } from './Driver/components/showvehicleinfo/vehicleinfo.component';
import { UpdateappealinfoComponent } from './Driver/components/updateappealinfo/updateappealinfo.component';
import { CreateappealComponent } from './Driver/components/createappeal/createappeal.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UpdatefuelcardinfoComponent } from './Driver/components/updatefuelcardinfo/updatefuelcardinfo.component';
import { UpdatecontactinfoComponent } from './Driver/components/updatecontactinfo/updatecontactinfo.component';
import { RouterModule, Routes } from '@angular/router';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { DashboardlayoutComponent } from './layout/dashboardlayout/dashboardlayout.component';


@NgModule({
  declarations: [
    AppComponent,
    Driverdetailscomponent,
    AppealinfoComponent,
    FuelcardinfoComponent,
    VehicleinfoComponent,
    UpdateappealinfoComponent,
    CreateappealComponent,
    UpdatefuelcardinfoComponent,
    UpdatecontactinfoComponent,
    SidebarComponent,
    NavbarComponent,
    FooterComponent,
    DashboardlayoutComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'showdriverdetails', component: Driverdetailscomponent },
      { path: 'updatecontactinfo', component: UpdatecontactinfoComponent },
      { path: 'updatefuelcardinfo', component: UpdatefuelcardinfoComponent },
      { path: 'showfuelcardinfo', component:  FuelcardinfoComponent},
      { path: 'updateappealinfo', component: UpdateappealinfoComponent },
      { path: 'showappealinfo', component: AppealinfoComponent }
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
  
})
export class AppModule { }
