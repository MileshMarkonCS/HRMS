import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChangePasswordComponent } from './components/security/user/change-password/change-password.component';
import { DashboardComponent } from './components/dynamic/dashboard/dashboard.component';
import { LoginComponent } from './components/security/auth/login/login.component';
import { WelcomeComponent } from './components/dynamic/welcome/welcome.component';
import { AuthGuard } from './components/security/auth/auth-guard';
import { CountryComponent } from './components/security/admin/regional/country/country.component';
import { CityComponent } from './components/security/admin/regional/city/city.component';
import { CoaComponent } from './components/fa/bk/setup/coa/coa.component';
import { CurrencyComponent } from './components/fa/bk/masters/currency/currency/currency.component';





const routes: Routes = [
  { path: '', component: WelcomeComponent },
  { path: 'welcome', component: WelcomeComponent },
  { path: 'login', component: LoginComponent },
  {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
          { path: 'dashboard', component: DashboardComponent },
          { path: 'changepassword', component: ChangePasswordComponent },
          { path: 'country', component: CountryComponent },
          { path: 'city', component: CityComponent },
          { path: 'coa', component: CoaComponent },
          { path: 'currency', component: CurrencyComponent },
          { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
      ]
  },
  { path: '**', redirectTo: 'welcome', pathMatch: 'full' }
];

@NgModule({
  imports: [
      RouterModule.forRoot(routes)
      ],
  exports: [
      RouterModule
  ]
})

export class AppRoutingModule { }
