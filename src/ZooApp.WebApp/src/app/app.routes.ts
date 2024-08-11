import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ZooComponent } from './pages/zoo/zoo.component';
import { ZooDetailsComponent } from './pages/zoo/details/zoo-details.component';

export const routes: Routes = [
    {
        path: '',
        component: DashboardComponent
    },
    {
        path: 'zoo',
        component: ZooComponent
    },
    {
        path: 'zoo/:id',
        component: ZooDetailsComponent
    }
];
