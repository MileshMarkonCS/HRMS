import { Component, OnInit } from '@angular/core';
import { COAModel } from './coa.model';
import { AuditModel } from 'src/app/components/misc/AuditParams.Model';
import { PageEvent, MatTableDataSource, MatDialog } from '@angular/material';
import { RightModel } from 'src/app/components/security/auth/rights.model';
import { PageSortComponent } from 'src/app/components/common/pageevents/page-sort/page-sort.component';
import { CoaEntryComponent } from './coa-entry/coa-entry.component';
import { CommonService } from 'src/app/components/common/common.service';
import { CoaService } from './coa.service';
import { UIService } from 'src/app/components/shared/uiservices/UI.service';
import { MessageBoxService } from 'src/app/components/messagebox/message-box.service';
import { AuthService } from 'src/app/components/security/auth/auth.service';

@Component({
  selector: 'app-coa',
  templateUrl: './coa.component.html',
  styleUrls: ['./coa.component.scss']
})
export class CoaComponent implements OnInit {
  displayedColumns: string[] =
  ['ledgerCode', 'ledger', 'ledgerGroupFlag', 'ledgerGroup', 'mainLedgerGroup', 'active', 'edit', 'delete', 'view'];

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
  private _Service: CoaService,
  private _ui: UIService,
  private _msg: MessageBoxService,
  private _auth: AuthService

) {
  this.pTableName = 'ledger';
  this.pScreenId = 10006;
  this.pTableId = 6;
  this.recordsPerPage = 10;
  this.currentPageIndex = 1;
  this.menuId = 1015381020;
}

ngOnInit() {
  this.refreshMe();
}

refreshMe() {
  this._cf.getPageData('ledger', this.pScreenId, this._auth.getUserId(), this.pTableId,
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
        (result: COAModel) => {
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

onAdd = function() {
  const result: COAModel = {
    ledgerId: 0,
    ledgerCode: '',
    ledger: '',
    ledgerGroupFlag: false,
    ledgerGroupId: 0,
    ledgerGroup: '',
    mainLedgerGroupId: 0,
    mainLedgerGroup: '',
    ledgerTypeId: 0,
    ledgerType: '',
    controlAccountId: 0,
    controlAccount: '',
    noJVPosting: false,
    automaticPostingId: 0,
    automaticPosting: '',
    currencyId: 0,
    currency: '',
    levelNo: 0,
    effectiveFrom: new Date(),
    effectiveTo: new Date(),
    analysisCodeApplicableFlag: false,
    costCenterApplication: false,
    active: false,
    entryMode: 'A',
    readOnly: false,
    auditColumns: null
  };
  this.openEntry(result);
};

onView = function (id: number) {
  this._ui.loadingStateChanged.next(true);
  this._Service.getEntry(id).subscribe((result: COAModel) => {
    this._ui.loadingStateChanged.next(false);
    result.entryMode = 'V';
    result.readOnly = true;
    this.openEntry(result);
  });
};

onEdit = function (id: number) {
  this._ui.loadingStateChanged.next(true);
  this._Service.getEntry(id).subscribe((result: COAModel) => {
    this._ui.loadingStateChanged.next(false);
    result.entryMode = 'E';
    result.readOnly = false;
    this.openEntry(result);
  });
};

onDelete = function (id: number) {
  this._ui.loadingStateChanged.next(true);
  this._Service.getEntry(id).subscribe((result: COAModel) => {
    this._ui.loadingStateChanged.next(false);
    result.entryMode = 'D';
    result.readOnly = true;
    this.openEntry(result);
  });
};

openEntry = function (pData?: COAModel) {
  if (pData === undefined) {
    this.dialogRef = this.dialog.open(CoaEntryComponent, {
      disableClose: true,
      data: {}
    });
  } else {
    this.dialogRef = this.dialog.open(CoaEntryComponent, {
      disableClose: true,
      data: pData
    });
  }
  this.dialogRef.afterClosed().subscribe((result: any) => {
    console.log('result ', result);
    this.refreshMe();
  });
};

onSort = function() {
  this.dialogRef = this.dialog.open(PageSortComponent, {
    disableClose: true,
    data: this.pTableId
  });
};
}
