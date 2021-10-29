import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { Driverdetailscomponent } from './Driver/driverdetails/driverdetails/driverdetails.component';

@NgModule({
  declarations: [
    AppComponent,
    Driverdetailscomponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
