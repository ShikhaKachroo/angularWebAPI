import { HttpInterceptor, HttpRequest, HttpHandler, HttpUserEvent, HttpEvent, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs";
//import { UserService } from "../user.service";
// import 'rxjs/add/operator/do';
import { map, tap, catchError, finalize } from "rxjs/operators";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { error } from 'util';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private router: Router) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        if (req.headers.get('No-Auth') == "True")
            return next.handle(req.clone());

        if (localStorage.getItem('userToken') != null) {
            const clonedreq = req.clone({
                headers: req.headers.set("Authorization", "Bearer " + localStorage.getItem('userToken'))
            });
            return next.handle(clonedreq)
                .pipe(
               
                tap((event: HttpEvent<any>) => {
                    
                }),
                catchError(err => {
                    if (err instanceof HttpErrorResponse) {
                        if (err.status === 401) {
                            console.log(err);
                            // JWT expired, go to login
                            // Observable.throw(err);
                        }
                    }
             
                    console.log('Caught error', err);
                    return Observable.throw(err);
                })
                );
        }
        else {
            this.router.navigateByUrl('/login');
        }
    }
}