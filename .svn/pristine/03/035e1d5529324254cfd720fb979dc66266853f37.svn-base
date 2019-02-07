import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SelectModel, IDModel } from 'src/app/components/misc/SelectModel';
import { HttpClient } from '@angular/common/http';
import { AppGlobals } from 'src/app/app.global';
import { map, catchError } from 'rxjs/operators';
import { CommonService } from 'src/app/components/common/common.service';
import { COAModel } from './coa.model';
import { Http, Response } from '@angular/http';

@Injectable({
  providedIn: 'root'
})
export class CoaService {

  constructor(
    private httpClient: HttpClient,
    private _globals: AppGlobals,
    private _cf: CommonService,
    private http: Http
  ) { }

  getLedgerGroup(pSearchText: string): Observable<SelectModel[]> {
    return this.httpClient.get<SelectModel[]>(this._globals.baseAPIUrl +
      'ddl/acledgergroup/' + pSearchText + '/0/' + true).pipe(
        map((response: SelectModel[]) => {
          return response;
        }), catchError(this._cf.handleError)
      );
  }
  getMainLedgerGroup(): Observable<SelectModel[]> {
    return this.httpClient.get<SelectModel[]>(this._globals.baseAPIUrl +
      'ddl/mainLedgergroup/').pipe(
        map((response: SelectModel[]) => {
          return response;
        }), catchError(this._cf.handleError)
      );
  }
  getMainLedgerGroupId(pLedgerId: number): Observable<IDModel> {
    return this.httpClient.get<IDModel>(this._globals.baseAPIUrl +
      'ledger/getMainLedgerGroupId/' + pLedgerId).pipe(
        map((response: IDModel) => {
          return response;
        }), catchError(this._cf.handleError)
      );
  }

  getLedgerSubmit(data: COAModel) {
    switch (data.entryMode) {
      case 'A': {
        return this.http.post(this._globals.baseAPIUrl + 'ledger/create', data, this._cf.requestOptions()).pipe(
          map((response: Response) => {
            return response.json();
          }), catchError(this._cf.handleError));
        break;
      }
      case 'E': {
        return this.http.post(this._globals.baseAPIUrl + 'ledger/edit', data, this._cf.requestOptions()).pipe(
          map((response: Response) => {
            return response.json();
          }), catchError(this._cf.handleError));
        break;
        }
        case 'D': {
        return this.http.post(this._globals.baseAPIUrl + 'ledger/delete', data, this._cf.requestOptions()).pipe(
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

  getEntry(pId: number) {
    return this.httpClient.get<COAModel>(this._globals.baseAPIUrl + 'ledger/' + pId).pipe(
      map((response: COAModel) => {
        return response;
      }),
      catchError(this._cf.handleError));
  }
}
