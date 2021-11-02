import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable, throwError } from "rxjs";
import { catchError, tap } from 'rxjs/operators';
import { IAppeal } from "../models/read/iappeal";
import { IDriverDetails } from "../models/read/idriver-details";
import { IFuelCard } from "../models/read/ifuel-card";
import { IVehicleDetails } from "../models/read/ivehicle-details";
import { ICreateAppeal } from "../models/write/icreate-appeal";
import { IUpdateAppealInfo } from "../models/write/iupdate-appeal-info";
import { IUpdateContactInfo } from "../models/write/iupdate-contact-info";
import { IUpdateFuelCardInfo } from "../models/write/iupdate-fuel-card-info";
import { IResponse } from "../models/standardresponse/iresponse";

@Injectable({ 
  providedIn: 'root'//creates a single, shared instance of service and injects it into any class that asks for it
})

export class DriverService {

  private readonly readApiUrl = 'https://localhost:44331/readapi/DriverZone';
  private readonly writeApiUrl = 'https://localhost:44383/writeapi/DriverZone';
  private readonly addPaging = '?PagingParameters.PageNumber=1&PagingParameters.PageSize=5'
  private readonly headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');


  constructor(private _httpClient: HttpClient) { }

  GetDriverDetails(id: number): Observable<IDriverDetails | undefined> 
  {
    return this._httpClient.get<IDriverDetails>(`${this.readApiUrl}/driver/${id}`)
    .pipe(  	
      tap(x => console.log('Data contains: ', JSON.stringify(x))), // js-object to json string
      catchError(x => this.handleError(x))); 
  }

  GetAppealsForDriver(id: number): Observable<IResponse<IAppeal>> 
  {
    return this._httpClient.get<IResponse<IAppeal>>(`${this.readApiUrl}/driver/${id}/appeals${this.addPaging}`)
    .pipe(  	
      tap(x => console.log('Data contains: ', JSON.stringify(x))),
      catchError(x => this.handleError(x)));
  }

  GetFuelCardsForDriver(id: number): Observable<IResponse<IFuelCard>> 
  {
    return this._httpClient.get<IResponse<IFuelCard>>(`${this.readApiUrl}/driver/${id}/fuelcards${this.addPaging}`)
    .pipe(  	
      tap(x => console.log('Data contains: ', JSON.stringify(x))),
      catchError(x => this.handleError(x)));
  }

  GetVehiclesForDriver(id: number): Observable<IResponse<IVehicleDetails>> 
  {
    return this._httpClient.get<IResponse<IVehicleDetails>>(`${this.readApiUrl}/driver/${id}/vehicles${this.addPaging}`)
    .pipe(  	
      tap(x => console.log('Data contains: ', JSON.stringify(x))),
      catchError(x => this.handleError(x)));
  }

  UpdateContactInfo(id: number, body: IUpdateContactInfo): Observable<any | undefined> 
  {
    return this._httpClient.put<any>(`${this.writeApiUrl}/driver/${id}`, body)
    .pipe(  	
      tap(x => console.log('Response contains: ', JSON.stringify(x))), 
      catchError(x => this.handleError(x))); 
  }

  UpdateFuelCardInfo(id: number, body: IUpdateFuelCardInfo): Observable<any | undefined> 
  {
    return this._httpClient.put<any>(`${this.writeApiUrl}/fuelCard/${id}`, body)
    .pipe(  	
      tap(x => console.log('Response contains: ', JSON.stringify(x))), 
      catchError(x => this.handleError(x))); 
  }

  UpdateAppealInfo(id: number, body: IUpdateAppealInfo): Observable<any | undefined> 
  {
    return this._httpClient.put<any>(`${this.writeApiUrl}/appeal/${id}`, body)
    .pipe(  	
      tap(x => console.log('Response contains: ', JSON.stringify(x))), 
      catchError(x => this.handleError(x))); 
  }

  CreateAppeal(body: ICreateAppeal): Observable<any | undefined> 
  {
    let bodyConverted = JSON.stringify(body);
    console.warn(bodyConverted);
    console.warn(body);
    return this._httpClient.post<any>(`${this.writeApiUrl}/appeal`, bodyConverted, { headers: this.headers })
    .pipe(  	
      tap(x => console.log('Response contains: ', JSON.stringify(x))), 
      catchError(x => this.handleError(x))); 
  }

  private handleError(errorResponse: HttpErrorResponse): Observable<never> // ? empty type set - the type of values that never occur
  {
    let errorMessage = '';
    if(errorResponse.error != null && errorResponse.error instanceof ErrorEvent) // ? double check needed?
        errorMessage = `An error occurred: ${errorResponse.error.message}`;
    else 
      errorMessage = `Server returned code: ${errorResponse.status}, error message is: ${errorResponse.message}`;

    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
