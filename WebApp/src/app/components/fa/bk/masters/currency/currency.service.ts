import { Injectable } from '@angular/core';
import { catchError, map } from 'rxjs/operators';
import { CommonService } from 'src/app/components/common/common.service';
import { CurrencyModel } from './currency.model';
import { AppGlobals } from 'src/app/app.global';
import { HttpClient } from '@angular/common/http';
import { Http, Response } from '@angular/http';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {

  constructor(
    private _cf: CommonService,
    private _globals: AppGlobals,
    private httpClient: HttpClient,
    private http: Http
  ) { }


  getCurrencyEntry(pId: number) {
    console.log('id', pId);
    return this.httpClient.get<CurrencyModel>(this._globals.baseAPIUrl + 'currency/' + pId).pipe(
      map((response: CurrencyModel) => {
        return response;
      }),
      catchError(this._cf.handleError));
  }

  getCurrencySubmit(data: CurrencyModel) {
    console.log('getCurrencySubmit');
    switch (data.entryMode) {
      case 'A': {
        return this.http.post(this._globals.baseAPIUrl + 'currency/create', data, this._cf.requestOptions()).pipe(
          map((response: Response) => {
            console.log('response', response);
            return response.json();
          }), catchError(this._cf.handleError));
        break;
      }
      case 'E': {
        return this.http.post(this._globals.baseAPIUrl + 'currency/edit', data, this._cf.requestOptions()).pipe(
          map((response: Response) => {
            return response.json();
          }), catchError(this._cf.handleError));
        break;
      }
      case 'D': {
        return this.http.post(this._globals.baseAPIUrl + 'currency/delete', data, this._cf.requestOptions()).pipe(
          map((response: Response) => {
            return response.json();
          }), catchError(this._cf.handleError));
        break;
      }
      default: {
        break;
      }
    }
  }
}
