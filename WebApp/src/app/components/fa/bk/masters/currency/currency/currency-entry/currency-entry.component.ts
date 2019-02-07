import { Component, OnInit, Inject } from '@angular/core';
import { UIService } from 'src/app/components/shared/uiservices/UI.service';
import { MessageBoxService } from 'src/app/components/messagebox/message-box.service';
import { AuthService } from 'src/app/components/security/auth/auth.service';
import { CommonService } from 'src/app/components/common/common.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { CurrencyModel } from '../../currency.model';
import { APIResultModel } from 'src/app/components/misc/APIResult.Model';
import { CurrencyService } from '../../currency.service';

@Component({
  selector: 'app-currency-entry',
  templateUrl: './currency-entry.component.html',
  styleUrls: ['./currency-entry.component.scss']
})
export class CurrencyEntryComponent implements OnInit {
  url: string;
  dialog_title: string;

  constructor(
      private _ui: UIService,
      private _msg: MessageBoxService,
      private _auth: AuthService,
      private _myService: CurrencyService,
      private dialogRef: MatDialogRef<CurrencyEntryComponent>,
      @Inject(MAT_DIALOG_DATA) public pModel: CurrencyModel
  ) { }

  ngOnInit() {
      console.log('pModel', this.pModel);
      switch (this.pModel.entryMode) {
          case 'A': {
              this.url = 'Currency/Create';
              this.dialog_title = 'Add';
              break;
          }
          case 'E': {
              this.url = 'Currency/Edit';
              this.dialog_title = 'Edit';
              break;
          }
          case 'D': {
              this.url = 'Currency/Delete';
              this.dialog_title = 'Delete';
              break;
          }
          case 'V': {
              this.url = 'Currency/View';
              this.dialog_title = 'View';
              break;
          }
          default: {
              this._msg.showError('Option not implemented..!');
              break;
          }
      }
  }

  onSubmit = function (form: CurrencyModel) {
      this._ui.loadingStateChanged.next(true);
      if (this.validateForm(form) !== true) {
          this._ui.loadingStateChanged.next(false);
          return false;
      }
      form.currencyId = this.pModel.currencyId;
      form.auditColumns = this._auth.getAuditColumns();
      form.entryMode = this.pModel.entryMode;
      try {
        console.log('reached here');
          this._myService.getCurrencySubmit(form).subscribe((result: APIResultModel) => {
              console.log('result', result);
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

  validateForm(form: CurrencyModel) {
      if (this.pModel.entryMode === 'E') {
          if (this.pModel.currencyId === 0 || this.pModel.currencyId === null) {
              this._msg.blank('Currency entry');
              return false;
          }
      }
      if (form.currencyCode === '' || form.currencyCode === null) {
          this._msg.blank('Code');
          return false;
      }
      if (form.currency === '' || form.currency === null) {
          this._msg.blank('Currency');
          return false;
      }
      if (form.description === '' || form.description === null) {
          this._msg.blank('Description');
          return false;
      }
      if (form.currencySymbol === '' || form.currencySymbol === null) {
          this._msg.blank('Symbol');
          return false;
      }
      return true;
  }
}
