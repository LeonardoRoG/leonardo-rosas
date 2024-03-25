import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import { AuthService } from "../auth.service";
import { AuthStatus } from "../interface/auth-status.enum";

export const isNotAuthenticatedGuard: CanActivateFn = (route, state) => {
    

    const authService = inject(AuthService);
    const router = inject(Router);

    if (authService.authStatus() === AuthStatus.authenticated){
        console.log(authService.authStatus());
        
        router.navigateByUrl('/');
        return false;
    }
    console.log('IsNotAuthenticatedGuard');
    return true;
}