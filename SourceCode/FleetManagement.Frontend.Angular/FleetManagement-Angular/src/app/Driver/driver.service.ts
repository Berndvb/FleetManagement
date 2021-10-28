import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable, throwError } from "rxjs";
import { catchError, tap } from 'rxjs/operators';
import { IDriverDetails } from "./models/idriver-details";

@Injectable({
  providedIn: 'root'
})
export class DriverService {

  private driverUrl = 'readapi/DriverZone/driver'; //need to check how HttpUrl is composed and sent.

  private relevantUrl = 'readapi/DriverZone/driver';


  constructor(private http: HttpClient) { }

  GetDriverDetails(id: number): Observable<IDriverDetails | undefined> 
  {
    return this.http.get<IDriverDetails>(`${this.driverUrl}/${id}`)
    .pipe(  	
      tap(data => console.log('Data contains: ', JSON.stringify(data))),
      catchError(this.handleError)); //no need to instert a parameter - how does this even work? 
  }

  GetAppealsForDriver(id: number): Observable<IDriverDetails | undefined> 
  {
    return this.http.get<IDriverDetails>(`${this.driverUrl}/${id}/appeals`)
    .pipe(  	
      tap(data => console.log('Data contains: ', JSON.stringify(data))),
      catchError(this.handleError));
  }

  private handleError(errorResponse: HttpErrorResponse): Observable<never>
  {
    let errorMessage = '';
    if(errorResponse.error instanceof ErrorEvent)
        errorMessage = `An error occurred: ${errorResponse.error.message}`;
    else 
      errorMessage = `Server returned code: ${errorResponse.status}, error message is: ${errorResponse.message}`;

    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
