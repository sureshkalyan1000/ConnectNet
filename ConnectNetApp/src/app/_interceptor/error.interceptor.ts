import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HttpResponse
} from '@angular/common/http';
import { Observable, catchError, map } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private route:Router, private toast:ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error:HttpErrorResponse)=>{
        if(error){
          switch(error.status){
            case 400:
              if(error.error.errors)
              {
                const arr=[];
                for(const key in error.error.errors)
                {
                  if(error.error.errors[key])
                  {
                    arr.push(error.error.errors[key]);
                  }
                }
                throw arr.flat()
              }
              else{
                this.toast.error(error.error, error.status.toString());
              }
              break;
            default:
              this.toast.error('SOmething went wrong unexpected')
              console.log(error);
              break;
          }          
        }
        throw error;
      })
    );
  }
}
