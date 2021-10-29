import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable, throwError } from "rxjs";
import { catchError, tap } from 'rxjs/operators';
import { IAppeal } from "./models/read/iappeal";
import { IDriverDetails } from "./models/read/idriver-details";
import { IFuelCard } from "./models/read/ifuel-card";
import { IVehicleDetails } from "./models/read/ivehicle-details";
import { ICreateAppeal } from "./models/read/write/icreate-appeal";
import { IUpdateAppealInfo } from "./models/read/write/iupdate-appeal-info";
import { IUpdateContactInfo } from "./models/read/write/iupdate-contact-info";
import { IUpdateFuelCardInfo } from "./models/read/write/iupdate-fuel-card-info";

@Injectable({ 
  providedIn: 'root'//creates a single, shared instance of service and injects it into any class that asks for it
})

export class DriverService {

  private baseUrl = 'https://localhost:44331/readapi/DriverZone';

  constructor(private _httpClient: HttpClient) { }

  GetDriverDetails(id: number): Observable<IDriverDetails | undefined> 
  {
    return this._httpClient.get<IDriverDetails>(`${this.baseUrl}/${id}`)
    .pipe(  	
      tap(x => console.log('Data contains: ', JSON.stringify(x))), // js-object to json string
      catchError(x => this.handleError(x))); 
  }

  GetAppealsForDriver(id: number): Observable<IAppeal[] | undefined> 
  {
    return this._httpClient.get<IAppeal[]>(`${this.baseUrl}/driver/${id}/appeals`)
    .pipe(  	
      tap(x => console.log('Data contains: ', JSON.stringify(x))),
      catchError(x => this.handleError(x)));
  }

  GetFuelCardsForDriver(id: number): Observable<IFuelCard[] | undefined> 
  {
    return this._httpClient.get<IFuelCard[]>(`${this.baseUrl}/driver/${id}/fuelcards`)
    .pipe(  	
      tap(x => console.log('Data contains: ', JSON.stringify(x))),
      catchError(x => this.handleError(x)));
  }

  GetVehiclesForDriver(id: number): Observable<IVehicleDetails[] | undefined> 
  {
    return this._httpClient.get<IVehicleDetails[]>(`${this.baseUrl}/driver/${id}/vehicles`)
    .pipe(  	
      tap(x => console.log('Data contains: ', JSON.stringify(x))),
      catchError(x => this.handleError(x)));
  }

  UpdateContactInfo(id: number, body: IUpdateContactInfo): Observable<any | undefined> 
  {
    return this._httpClient.put<any>(`${this.baseUrl}/driver/${id}`, body)
    .pipe(  	
      tap(x => console.log('Response contains: ', JSON.stringify(x))), 
      catchError(x => this.handleError(x))); 
  }

  UpdateFuelCardInfo(id: number, body: IUpdateFuelCardInfo): Observable<any | undefined> 
  {
    return this._httpClient.put<any>(`${this.baseUrl}/fuelCard/${id}`, body)
    .pipe(  	
      tap(x => console.log('Response contains: ', JSON.stringify(x))), 
      catchError(x => this.handleError(x))); 
  }

  UpdateAppealInfo(id: number, body: IUpdateAppealInfo): Observable<any | undefined> 
  {
    return this._httpClient.put<any>(`${this.baseUrl}/appeal/${id}`, body)
    .pipe(  	
      tap(x => console.log('Response contains: ', JSON.stringify(x))), 
      catchError(x => this.handleError(x))); 
  }

  CreateAppeal(body: ICreateAppeal): Observable<any | undefined> 
  {
    return this._httpClient.post<any>(`${this.baseUrl}/appeal`, body)
    .pipe(  	
      tap(x => console.log('Response contains: ', JSON.stringify(x))), 
      catchError(x => this.handleError(x))); 
  }

  private handleError(errorResponse: HttpErrorResponse): Observable<never>
  {
    let errorMessage = '';
    if(errorResponse.error != null && errorResponse.error instanceof ErrorEvent) //double check needed?
        errorMessage = `An error occurred: ${errorResponse.error.message}`;
    else 
      errorMessage = `Server returned code: ${errorResponse.status}, error message is: ${errorResponse.message}`;

    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
