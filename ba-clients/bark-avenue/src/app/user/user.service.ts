import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { BehaviorSubject, catchError, map, Observable, throwError } from "rxjs";

import { IUser, IUserCredentials, IUserSignUpCredentials } from "./user.model";

@Injectable({
    providedIn: 'root',
})

export class UserService {
    private user: BehaviorSubject<IUser | null>;

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