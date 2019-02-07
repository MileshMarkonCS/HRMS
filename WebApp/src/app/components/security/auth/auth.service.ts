import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { AppGlobals } from 'src/app/app.global';
import { map, catchError, switchMap } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CommonService } from '../../common/common.service';
import { Router } from '@angular/router';
import { AuditModel } from '../../misc/AuditParams.Model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  userToken: any;
  decodedToken: any;
  jwtHelper: JwtHelperService = new JwtHelperService();

  constructor(
    private http: Http,
    private _globals: AppGlobals,
    private _cf: CommonService,
    private jwtHelperService: JwtHelperService,
    private router: Router
  ) { }

  login(model: any) {
    return this.http.post(this._globals.baseAPIUrl + 'user/login', model, this._cf.requestOptions()).pipe(
      map((response: Response) => {
        const user = response.json();
        if (user) {
          localStorage.setItem(this._globals.baseAppName + '_token', user.token);
          this.userToken = user.token;
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          return response.json();
        } else {
          return null;
        }
      }), catchError(this._cf.handleError)
    );
  }

  loggedIn() {
    const mToken = this.jwtHelperService.tokenGetter();
    // return !!mToken;
    return !this.jwtHelperService.isTokenExpired(mToken);
  }

  logout() {
    this.userToken = null;
    this.decodedToken = null;
    localStorage.removeItem(this._globals.baseAppName + '_token');
    this.router.navigate(['/welcome']);
  }

  getToken() {
    return localStorage.getItem(this._globals.baseAppName + '_token');
  }

  getUserId() {
    return this.jwtHelperService.decodeToken(this.getToken()).nameid;
  }

  getDeviceType() {
    return window.clientInformation.platform;
  }

  getHostName() {
    return 'unidentified';
  }

  getIPAddress() {
    return 'unidentified';
  }

  getMACAddress() {
    return 'unidentified';
  }

  getScreenRights(pMenuId: number) {
    return this.http.post(this._globals.baseAPIUrl + 'menu/getScreenRights/' +
      this.getUserId() + '/' + pMenuId, [], this._cf.requestOptions()).pipe(
      map((response: Response) => {
          return response.json();
      }), catchError(this._cf.handleError)
    );
  }

  getAuditColumns() {
    const data = new AuditModel (
      1100001,
      1,
      10001,
      1,
      this.getUserId(),
      this.getMACAddress(),
      this.getHostName(),
      this.getIPAddress(),
      this.getDeviceType()
    );
    return data;
  }

}
