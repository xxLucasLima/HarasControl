import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { authGuard } from './auth/auth.guard';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AnimalsListComponent } from './animals/animals-list/animals-list.component';
import { AnimalDetailsComponent } from './animals/animal-details/animal-details/animal-details.component';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [authGuard],
    children: [
      {
        path: 'animals/home',
        component: AnimalsListComponent,
        canActivate: [authGuard],
        data: { roles: ['HarasOwner'] }
      },
      {
        path: 'animals/:id',
        component: AnimalDetailsComponent,
        canActivate: [authGuard],
        data: { roles: ['HarasOwner'] }
      }
    ]
  }
];

