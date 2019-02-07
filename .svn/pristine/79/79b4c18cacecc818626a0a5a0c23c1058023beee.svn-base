import { Component, ElementRef, AfterViewInit, OnDestroy, OnInit } from '@angular/core';
import { AppGlobals } from 'src/app/app.global';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from './components/security/auth/auth.service';
import { UIService } from './components/shared/uiservices/UI.service';
import { MatDialog } from '@angular/material';
import { Subscription } from 'rxjs';
import { PleaseWaitComponent } from './components/shared/uiservices/please-wait/please-wait.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterViewInit, OnInit, OnDestroy {

  jwtHelperService: JwtHelperService = new JwtHelperService();
  isLoading = false;
  private loadingSubs: Subscription;

  constructor(
    private _globals: AppGlobals,
    private _auth: AuthService,
    private _ui: UIService,
    public dialog: MatDialog,
    private elementRef: ElementRef
  ) { }

  ngAfterViewInit() {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = '#f2f5f7';
  }

  ngOnInit() {
    this.loadingSubs = this._ui.loadingStateChanged.subscribe(isLoading => {
      if (isLoading === true) {
        this.dialog.open(PleaseWaitComponent);
      }
    });
    const token = localStorage.getItem(this._globals.baseAppName + '_token');
    if (token) {
      this._auth.decodedToken = this.jwtHelperService.decodeToken(token);
    }

  }

  ngOnDestroy() {
    this.loadingSubs.unsubscribe();
  }

  isLoggedIn() {
    return this._auth.loggedIn();
  }

}
