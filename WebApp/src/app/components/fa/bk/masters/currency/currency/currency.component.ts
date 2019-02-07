import { Component, OnInit } from '@angular/core';
import { RightModel } from 'src/app/components/security/auth/rights.model';
import { MatDialog, MatTableDataSource, PageEvent } from '@angular/material';
import { CommonService } from 'src/app/components/common/common.service';
import { UIService } from 'src/app/components/shared/uiservices/UI.service';
import { MessageBoxService } from 'src/app/components/messagebox/message-box.service';
import { AuthService } from 'src/app/components/security/auth/auth.service';
import { CurrencyModel } from '../currency.model';
import { CurrencyEntryComponent } from './currency-entry/currency-entry.component';
import { PageSortComponent } from 'src/app/components/common/pageevents/page-sort/page-sort.component';
import { CurrencyService } from '../currency.service';

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html',
  styleUrls: ['./currency.component.scss']
})
export class CurrencyComponent implements OnInit {
  displayedColumns: string[] =
    ['currencyCode', 'currency', 'description', 'currencySymbol', 'active', 'edit', 'view'];

  dataSource: any;
  isLastPage = false;
  pTableName: string;
  pScreenId: number;
  pTableId: number;
  recordsPerPage: number;
  currentPageIndex: number;
  menuId: number;

  // MatPaginator Inputs
  totalRecords: number;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  // Screen Rights
  screenRights: RightModel = {
    amendFlag: false,
    createFlag: false,
    deleteFlag: false,
    editFlag: false,
    exportFlag: false,
    printFlag: false,
    reverseFlag: false,
    shortCloseFlag: false,
    viewFlag: false
  };

  constructor(
    public dialog: MatDialog,
    private _cf: CommonService,
    private _Service: CurrencyService,
    private _ui: UIService,
    private _msg: MessageBoxService,
    private _auth: AuthService

  ) {
    this.pTableName = 'currency';
    this.pScreenId = 10002;
    this.pTableId = 2;
    this.recordsPerPage = 10;
    this.currentPageIndex = 1;
    this.menuId = 1012415000;
  }

  ngOnInit() {
    this.refreshMe();
  }

  refreshMe() {
    this._cf.getPageData('currency', this.pScreenId, this._auth.getUserId(), this.pTableId,
      this.recordsPerPage, this.currentPageIndex, false).subscribe(
        (result) => {
          this.totalRecords = result[0].totalRecords;
          this.recordsPerPage = 10;
          this.dataSource = new MatTableDataSource(result);
        }
      );
    this._auth.getScreenRights(this.menuId).subscribe((rights: RightModel) => {
      this.screenRights = rights;
    });
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  paginatoryOperation(event: PageEvent) {
    try {
      this._cf.getPageDataOnPaginatorOperation(event, this.pTableName, this.pScreenId, this._auth.getUserId(),
        this.pTableId, this.totalRecords).subscribe(
          (result: CurrencyModel) => {
            console.log('result', result);
            this._ui.loadingStateChanged.next(false);
            this.totalRecords = result[0].totalRecords;
            this.recordsPerPage = event.pageSize;
            this.dataSource = result;
          }, error => {
            this._ui.loadingStateChanged.next(false);
            this._msg.showAPIError(error);
            return false;
          });
    } catch (error) {
      this._ui.loadingStateChanged.next(false);
      this._msg.showAPIError(error);
      return false;
    }
  }

  onAdd = function () {
    const result: CurrencyModel = {
      currency: '',
      currencyCode: '',
      currencySymbol: '',
      currencyId: 0,
      description: '',
      active: false,
      entryMode: 'A',
      readOnly: false,
      auditColumns: null
    };
    this.openEntry(result);
  };

  onView = function (id: number) {
    this._ui.loadingStateChanged.next(true);
    this._Service.getCurrencyEntry(id).subscribe((result: CurrencyModel) => {
      this._ui.loadingStateChanged.next(false);
      result.entryMode = 'V';
      result.readOnly = true;
      this.openEntry(result);
    });
  };

  onEdit = function (id: number) {
    this._ui.loadingStateChanged.next(true);
    this._Service.getCurrencyEntry(id).subscribe((result: CurrencyModel) => {
      this._ui.loadingStateChanged.next(false);
      result.entryMode = 'E';
      result.readOnly = false;
      this.openEntry(result);
    });
  };

  openEntry = function (pData?: CurrencyModel) {
    if (pData === undefined) {
      this.dialogRef = this.dialog.open(CurrencyEntryComponent, {
        disableClose: true,
        data: {}
      });
    } else {
      this.dialogRef = this.dialog.open(CurrencyEntryComponent, {
        disableClose: true,
        data: pData
      });
    }
    this.dialogRef.afterClosed().subscribe((result: any) => {
      console.log('result ', result);
      this.refreshMe();
    });
  };

  onSort = function () {
    this.dialogRef = this.dialog.open(PageSortComponent, {
      disableClose: true,
      data: this.pTableId
    });
  };
}
