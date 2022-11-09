import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, tap } from 'rxjs/operators';
import {IFilm} from './Film';
@Injectable({
    providedIn: 'root'
}) 

export class EmpleadoService {
    constructor(private http: HttpClient){}
    public baseUrl: string = "http://localhost:5000/";
    public endpointGet: string = "Films";
  

    htppOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }
    getData(): Observable<IFilm[]>{
        return this.http.get<IFilm[]>(this.baseUrl + this.endpointGet).pipe(
            catchError(this.handleError)
        );
    }
    private handleError(err: HttpErrorResponse): Observable<never> {
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
          errorMessage = `An error occurred: ${err.error.message}`;
        } else {
          errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return throwError(errorMessage);
    }
    
}