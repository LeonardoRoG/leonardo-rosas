import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import { AuthService } from "../auth.service";

export const redireccionGuard: CanActivateFn = (route, state) => {
    console.log('Redireccion guard', route);

    const authService = inject(AuthService);
    const router = inject(Router);
    
    const currentRol = authService.currentUser()?.role;

    if (currentRol === 'cliente'){
        router.navigateByUrl('/');
        return true;
    } else if (currentRol === 'administrador'){
        router.navigateByUrl('/producto');
        return true;
    }

    router.navigateByUrl('/auth');
    return true;
}