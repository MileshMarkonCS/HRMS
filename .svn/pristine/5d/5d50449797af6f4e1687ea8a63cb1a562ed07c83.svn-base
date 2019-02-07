import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { AppGlobals } from 'src/app/app.global';
import { CommonService } from './common.service';
import { Observable } from 'rxjs';
import { SelectModel } from '../misc/SelectModel';
import { map, catchError } from 'rxjs/operators';
import { AuthService } from '../security/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class SelectService {

  constructor(
    private http: Http,
    private httpClient: HttpClient,
    private _globals: AppGlobals,
    private _cf: CommonService,
    private _auth: AuthService
  ) { }

  getMisc(pMiscId: number, pParentMiscId: number, pNoneRequired: boolean): Observable<SelectModel[]> {
    return this.httpClient.get<SelectModel[]>(this._globals.baseAPIUrl +
        'Common/selectddlmisc/' + pMiscId + '/' + pParentMiscId + '/' + pNoneRequired).pipe(
      map((response: SelectModel[]) => {
        return response;
      }), catchError(this._cf.handleError)
    );
  }

  getPageSortColumns(pTableId: number): Observable<SelectModel[]> {
    return this.httpClient.get<SelectModel[]>(this._globals.baseAPIUrl +
        'Ddl/ddlSortColumn/' + pTableId + '/' + this._auth.getUserId()).pipe(
      map((response: SelectModel[]) => {
        return response;
      }), catchError(this._cf.handleError)
    );
  }

  getCurrency(pNoneRequired: boolean): Observable<SelectModel[]> {
    return this.httpClient.get<SelectModel[]>(this._globals.baseAPIUrl +
        'Ddl/currency/' + pNoneRequired).pipe(
      map((response: SelectModel[]) => {
        return response;
      }), catchError(this._cf.handleError)
    );
  }

}
