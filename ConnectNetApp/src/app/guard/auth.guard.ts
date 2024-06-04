import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from '../service/account.service';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
  const service = inject(AccountService);
  const toast = inject(ToastrService);

  return service.userSource$.pipe(
    map(
      res => {
        if(res) return true;
        else {
          toast.error('you shall not pass!');
          return false;
        }
      }
    )
  )
  
};
