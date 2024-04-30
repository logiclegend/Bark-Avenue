import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { BehaviorSubject, catchError, map, Observable, throwError } from "rxjs";

import { IUser, IUserCredentials, IUserSignUpCredentials } from "./user.model";

@Injectable({
    providedIn: 'root',
})

export class UserService {
    private user: BehaviorSubject<IUser | null>;

    // private handleError(error: HttpErrorResponse) {
    //     if (error.status === 0) {
    //       // A client-side or network error occurred. Handle it accordingly.
    //       console.error('An error occurred:', error.error);
    //     } else {
    //       // The backend returned an unsuccessful response code.
    //       // The response body may contain clues as to what went wrong.
    //       console.error(
    //         `Backend returned code ${error.status}, body was: `, error.error);
    //     }
    //     // Return an observable with a user-facing error message.
    //     return throwError(() => new Error('Something bad happened; please try again later.'));
    //   }
    
    constructor(private http: HttpClient) {
        this.user = new BehaviorSubject<IUser | null>(null);
    }

    getUser(): Observable<IUser | null> {
        return this.user
    }

    signIn(credentials: IUserCredentials): Observable<IUser>{
        return this.http
            .post<IUser>('/api/sign-in' , credentials)
            .pipe(map((user: IUser) => {
                this.user.next(user);
                return user
            }))
    }


    signUp(credentials: IUserSignUpCredentials): Observable<string> {
        return this.http.post('/api/Registration', credentials, { responseType: "text" });
      }

    signOut(){
        this.user.next(null);
    }

    

}