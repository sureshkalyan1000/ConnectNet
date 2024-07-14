import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { AccountService } from '../service/account.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private acc:AccountService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.acc.userSource$.pipe(take(1)).subscribe({
      next: res =>{
        if(res){
          request=request.clone({
            setHeaders:{
              Authorization : 'Bearer '+res.token
            }
          })
        }
      }
    })
    return next.handle(request);
  }
}
