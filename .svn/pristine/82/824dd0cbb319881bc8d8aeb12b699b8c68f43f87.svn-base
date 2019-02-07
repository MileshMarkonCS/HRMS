import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import { HttpModule } from '@angular/http';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { DatePipe } from '@angular/common';
import { MaterialModule } from 'src/app/material.module';
import { MenuItemComponent } from './components/dynamic/menu/menu-item/menu-item.component';
import { AppGlobals } from './app.global';
import { CommonService } from './components/common/common.service';
import { MenuBarComponent } from './components/dynamic/menu/menu-bar/menu-bar.component';
import { DashboardComponent } from './components/dynamic/dashboard/dashboard.component';
import { ChartModule } from 'angular2-chartjs';
import { ChangePasswordComponent } from './components/security/user/change-password/change-password.component';
import { UIService } from './components/shared/uiservices/UI.service';
import { MessageBoxService } from './components/messagebox/message-box.service';
import { UserService } from './components/security/user/user.service';
import { ErrorBoxComponent } from './components/messagebox/error-box/error-box.component';
import { ErrorApiBoxComponent } from './components/messagebox/error-api-box/error-api-box.component';
import { WarningBoxComponent } from './components/messagebox/warning-box/warning-box.component';
import { PleaseWaitComponent } from './components/shared/uiservices/please-wait/please-wait.component';
import { LoginComponent } from './components/security/auth/login/login.component';
import { LandingMenuComponent } from './components/dynamic/menu/landing-menu/landing-menu.component';
import { WelcomeComponent } from './components/dynamic/welcome/welcome.component';
import { TokenInterceptor } from './token-interceptor';
import { AuthGuard } from './components/security/auth/auth-guard';
import { AuthService } from './components/security/auth/auth.service';
import { CityComponent } from './components/security/admin/regional/city/city.component';
import { RegionalService } from './components/security/admin/regional/regional.service';
import { CountryComponent } from './components/security/admin/regional/country/country.component';
import { CountryEntryComponent } from './components/security/admin/regional/country/country-entry/country-entry.component';
import { PageEventsService } from './components/common/pageevents/page-events.service';
import { SelectService } from './components/common/select.service';
import { PageSortComponent } from './components/common/pageevents/page-sort/page-sort.component';
import { CoaComponent } from './components/fa/bk/setup/coa/coa.component';
import { CoaEntryComponent } from './components/fa/bk/setup/coa/coa-entry/coa-entry.component';
import { CoaService } from './components/fa/bk/setup/coa/coa.service';
import { CurrencyComponent } from './components/fa/bk/masters/currency/currency/currency.component';
import { CurrencyEntryComponent } from './components/fa/bk/masters/currency/currency/currency-entry/currency-entry.component';
import { CurrencyService } from './components/fa/bk/masters/currency/currency.service';





export function getAccessToken(): string {
  return localStorage.getItem('AMT.ERP_token');
}

export const jwtConfig = {
  tokenGetter: getAccessToken,
  whiteListedDomains: ['localhost:4200']
};

@NgModule({
  declarations: [
    AppComponent,
    ChangePasswordComponent,
    DashboardComponent,
    ErrorBoxComponent,
    ErrorApiBoxComponent,
    WarningBoxComponent,
    PleaseWaitComponent,
    MenuBarComponent,
    MenuItemComponent,
    LoginComponent,
    LandingMenuComponent,
    WelcomeComponent,
    CountryComponent,
    CountryEntryComponent,
    CityComponent,
    PageSortComponent,
    CoaComponent,
    CoaEntryComponent,
    CurrencyComponent,
    CurrencyEntryComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ChartModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: jwtConfig
    }),
    MaterialModule,

  ],
  providers: [
    AppGlobals,
    AuthGuard,
    AuthService,
    CommonService,
    RegionalService,
    DatePipe,
    MessageBoxService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    UIService,
    UserService,
    PageEventsService,
    SelectService,
    CoaService,
    CurrencyService
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    ErrorBoxComponent,
    ErrorApiBoxComponent,
    WarningBoxComponent,
    PleaseWaitComponent,
    CountryEntryComponent,
    PageSortComponent,
    CoaEntryComponent,
    CurrencyEntryComponent
  ]
})
export class AppModule { }
