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


@NgModule({
  declarations: [
    AppComponent,
    Driverdetailscomponent,
    AppealinfoComponent,
    FuelcardinfoComponent,
    VehicleinfoComponent,
    UpdateappealinfoComponent,
    CreateappealComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
