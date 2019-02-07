import { Component, OnInit, Inject } from '@angular/core';
import { UIService } from 'src/app/components/shared/uiservices/UI.service';
import { MessageBoxService } from 'src/app/components/messagebox/message-box.service';
import { AuthService } from 'src/app/components/security/auth/auth.service';
import { MatDialogRef, MAT_DIALOG_DATA, MAT_DATE_FORMATS, DateAdapter, MAT_DATE_LOCALE } from '@angular/material';
import { COAModel } from '../coa.model';
import { APIResultModel } from 'src/app/components/misc/APIResult.Model';
import { SelectModel, IDModel } from 'src/app/components/misc/SelectModel';
import { CommonService } from 'src/app/components/common/common.service';
import { SelectService } from 'src/app/components/common/select.service';
import { FormControl } from '@angular/forms';
import { Observable, of, TimeoutError } from 'rxjs';
import { startWith, switchMap, map } from 'rxjs/operators';
import { CoaService } from '../coa.service';
import { defaultThrottleConfig } from 'rxjs/internal/operators/throttle';

@Component({
  selector: 'app-coa-entry',
  templateUrl: './coa-entry.component.html',
  styleUrls: ['./coa-entry.component.scss'],
})
export class CoaEntryComponent implements OnInit {
  url: string;
  dialog_title: string;

  public pLedgerGroups: Observable<any> = null;
  public ledgerGroup = new FormControl();
  pLedgerTypes: SelectModel[];
  pMainLedgerGroups: SelectModel[];
  pControlAccounts: SelectModel[];
  pAutomaticPostings: SelectModel[];
  pCurrencies: SelectModel[];
  pDisableControls: boolean;
  pDisableControlAccount: boolean;
  pDisableAutomaticPosting: boolean;

  constructor(
    private _ui: UIService,
    private _msg: MessageBoxService,
    private _auth: AuthService,
    private _myService: CoaService,
    private _cf: CommonService,
    private _select: SelectService,
    private dialogRef: MatDialogRef<CoaEntryComponent>,
    @Inject(MAT_DIALOG_DATA) public pModel: COAModel
  ) { }

  ngOnInit() {
    switch (this.pModel.entryMode) {
      case 'A': {
        this.url = 'Coa/Create';
        this.dialog_title = 'Add';
        break;
      }
      case 'E': {
        this.url = 'Coa/Edit';
        this.dialog_title = 'Edit';
        break;
      }
      case 'D': {
        this.url = 'Coa/Delete';
        this.dialog_title = 'Delete';
        break;
      }
      case 'V': {
        this.url = 'Coa/View';
        this.dialog_title = 'View';
        break;
      }
      default: {
        this._msg.showError('Option not implemented..!');
        break;
      }
    }
    this._select.getMisc(301, 1, false).subscribe((res: SelectModel[]) => {
      this.pLedgerTypes = res;
      this.pModel.ledgerTypeId = 30100001;
    });

    this.pLedgerGroups = this.ledgerGroup.valueChanges.pipe(
      startWith(''),
      switchMap(value => {
        if (value !== '') {
          return this.lookup(value);
        } else {
          return of(null);
        }
      })
    );

    this._myService.getMainLedgerGroup().subscribe((res: SelectModel[]) => {
      this.pMainLedgerGroups = res;
      this.pModel.mainLedgerGroupId = 1;
    });
    this._select.getMisc(401, 1, true).subscribe((res: SelectModel[]) => {
      this.pControlAccounts = res;
      this.pModel.controlAccountId = 1;
    });
    this._select.getMisc(411, 1, true).subscribe((res: SelectModel[]) => {
      this.pAutomaticPostings = res;
      this.pModel.automaticPostingId = 1;
    });
    this._select.getCurrency(true).subscribe((res: SelectModel[]) => {
      this.pCurrencies = res;
      this.pModel.currencyId = 1;
    });
    this.pDisableControls = false;
    this.pDisableControlAccount = true;
    this.pDisableAutomaticPosting = true;
    this.pModel.effectiveFrom = new Date('01/01/1900');
    this.pModel.effectiveTo = new Date('31/12/2099');
  }

  lookup(value: string): Observable<any> {
    return this._myService.getLedgerGroup(value.toLowerCase()).pipe(
      map(results => results)
    );
  }

  onLedgerType (id: number) {
    switch (id) {
      case 30100001: {
        this.pDisableAutomaticPosting = true;
        this.pDisableControlAccount = true;
        break;
      }
      case 30100002: {
        this.pDisableAutomaticPosting = true;
        this.pDisableControlAccount = false;
        break;
      }
      case 30100003: {
        this.pDisableAutomaticPosting = false;
        this.pDisableControlAccount = true;
        break;
      }
      default: {
        this.pDisableAutomaticPosting = true;
        this.pDisableControlAccount = true;
        break;
      }
    }
  }

  onLedgerGroupFlagChange(value) {
    if (value === true) {
      this.pModel.noJVPosting = false;
      this.pModel.currencyId = 1;
      this.pDisableControls = true;
      this.pModel.effectiveFrom = new Date('01/01/1900');
      this.pModel.effectiveTo = new Date('31/12/2099');
    } else {
      this.pDisableControls = false;
    }
  }

  onLedgerGroupChange (id: number) {
    if (id === 50001 || id === 50002 || id === 50003 ||
      id === 50004 || id === 50005) {
        this.pModel.mainLedgerGroupId = id;
        this.changeControlAccountValues();
      } else {
        this._myService.getMainLedgerGroupId(id).subscribe((mainGroupId: IDModel) => {
          this.pModel.mainLedgerGroupId = mainGroupId.id;
          this.changeControlAccountValues();
        });
    }
  }

  changeControlAccountValues() {
    let lCAParentMiscDetaiId: number;
    let lAPParentMiscDetaiId: number;
    switch (this.pModel.mainLedgerGroupId) {
      case 50001 : {
        lCAParentMiscDetaiId = 40100001;
        lAPParentMiscDetaiId = 41100001;
        break;
      }
      case 50002 : {
        lCAParentMiscDetaiId = 40100002;
        lAPParentMiscDetaiId = 41100002;
        break;
      }
      case 50003 : {
        lCAParentMiscDetaiId = 40100003;
        lAPParentMiscDetaiId = 41100003;
        break;
      }
      case 50004 : {
        lCAParentMiscDetaiId = 40100004;
        lAPParentMiscDetaiId = 41100004;
        break;
      }
      case 50005 : {
        lCAParentMiscDetaiId = 40100005;
        lAPParentMiscDetaiId = 41100005;
        break;
      }
      default : {
        lCAParentMiscDetaiId = 0;
        break;
      }
    }
  this.pModel.controlAccountId = 1;
    this._select.getMisc(401, lCAParentMiscDetaiId, true).subscribe((res: SelectModel[]) => {
      this.pControlAccounts = res;
      this.pModel.controlAccountId = 1;
    });
  this._select.getMisc(411, lAPParentMiscDetaiId, true).subscribe((res: SelectModel[]) => {
      this.pAutomaticPostings = res;
      this.pModel.automaticPostingId = 1;
    });
  }

  onSubmit = function (form: COAModel) {
    this._ui.loadingStateChanged.next(true);
    if (this.validateForm(form) !== true) {
      this._ui.loadingStateChanged.next(false);
      return false;
    }
    form.ledgerId = this.pModel.countryId;
    form.auditColumns = this._auth.getAuditColumns();
    form.entryMode = this.pModel.entryMode;
    try {
      this._myService.getLedgerSubmit(form).subscribe((result: APIResultModel) => {
        if (result.errorNo === 0) {
          this._ui.loadingStateChanged.next(false);
          this._msg.showInfo(result.errorMessage);
          this.dialogRef.close();
        } else {
          this._ui.loadingStateChanged.next(false);
          this._msg.showError(result.errorMessage);
          return false;
        }
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
  };

  onCancel() {
    this.dialogRef.close();
  }

  validateForm(form: COAModel) {
    if (this.pModel.entryMode === 'E') {
      if (this.pModel.ledgerId === 0 || this.pModel.ledgerId === null) {
        this._msg.blank('Chat of account entry');
        return false;
      }
    }
    if (form.ledgerCode === '' || form.ledgerCode === null) {
      this._msg.blank('Code');
      return false;
    }
    if (form.ledger === '' || form.ledger === null) {
      this._msg.blank('Ledger');
      return false;
    }
    if (form.ledgerGroupId <= 0 || form.ledgerGroupId === null) {
      this._msg.blank('Ledger group');
      return false;
    }
    if (form.mainLedgerGroupId <= 0 || form.mainLedgerGroupId === null) {
      this._msg.blank('Main ledger group');
      return false;
    }
    if (form.ledgerTypeId <= 1 || form.ledgerTypeId === null) {
      this._msg.blank('Ledger type');
      return false;
    }
    if (form.controlAccountId <= 0 || form.controlAccountId === null) {
      this._msg.blank('control account');
      return false;
    }
    if (form.automaticPostingId <= 0 || form.controlAccountId === null) {
      this._msg.blank('Automatic postingId');
      return false;
    }
    if (form.currencyId <= 1 || form.currencyId === null) {
      this._msg.blank('Currency');
      return false;
    }
    if (form.effectiveFrom === null) {
      this._msg.blank('Effective from date');
      return false;
    }
    if (form.effectiveTo === null) {
      this._msg.blank('Effective to date');
      return false;
    }
    if (form.effectiveFrom > form.effectiveTo) {
      this._msg.greaterThenEqualTo('Effective from date', 'Effective to date');
      return false;
    }
    return true;
  }
}
