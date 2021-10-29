import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppealinfoComponent } from './Driver/components/appealinfo/appealinfo.component';
import { Driverdetailscomponent } from './Driver/components/driverdetails/driverdetails.component';
import { FuelcardinfoComponent } from './Driver/components/fuelcardinfo/fuelcardinfo.component';
import { VehicleinfoComponent } from './Driver/components/vehicleinfo/vehicleinfo.component';


@NgModule({
  declarations: [
    AppComponent,
    Driverdetailscomponent,
    AppealinfoComponent,
    FuelcardinfoComponent,
    VehicleinfoComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
