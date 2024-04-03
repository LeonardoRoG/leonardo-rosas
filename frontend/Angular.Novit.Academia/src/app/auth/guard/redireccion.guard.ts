import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import { AuthService } from "../auth.service";

export const redireccionGuard: CanActivateFn = (route, state) => {
    console.log('Redireccion guard', route);

    const authService = inject(AuthService);
    const router = inject(Router);
    
    const currentRol = authService.currentUser()?.role;

    if (currentRol === 'vendedor'){
        router.navigateByUrl('/producto/productos');
        return true;
    } else if (currentRol === 'comercial'){
        router.navigateByUrl('/reserva/reservas');
        return true;
    }

    router.navigateByUrl('/auth');
    return true;
}