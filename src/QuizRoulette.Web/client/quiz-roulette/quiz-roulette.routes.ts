import { Routes } from '@angular/router';
import { HelloWorldComponent } from './hello-world/hello-world.component';

export const appRoutes: Routes = [{
    path: 'hello',
    component: HelloWorldComponent
}, {
    path: '**',
    redirectTo: 'hello'
}];
