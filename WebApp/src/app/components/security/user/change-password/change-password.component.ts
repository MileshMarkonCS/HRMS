import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { UIService } from 'src/app/components/shared/uiservices/UI.service';
import { MessageBoxService } from 'src/app/components/messagebox/message-box.service';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { ChangePasswordModel } from './change-password.model';
import { APIResultModel } from 'src/app/components/misc/APIResult.Model';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {

  constructor (
    private uiService: UIService,
    private _msg: MessageBoxService,
    private userService: UserService,
    private router: Router
  ) { }

  pModel: ChangePasswordModel;

  ngOnInit() {

  }

  changePassword(form: NgForm) {
    this.uiService.loadingStateChanged.next(true);
    if (form.invalid) {
      this.uiService.loadingStateChanged.next(false);
      this._msg.FillRequired();
      return false;
    }
    if (form.value.password !== form.value.confirmpassword) {
      this.uiService.loadingStateChanged.next(false);
      this._msg.showError('Password not matching with confirm password!');
      return false;
    }
    this.userService.changepassword(form.value).subscribe((response: any) => {
      this.uiService.loadingStateChanged.next(false);
      this.router.navigate(['/dashboard']);
      this._msg.success('Password updation');
    }, error => {
      this.uiService.loadingStateChanged.next(false);
      console.log('before show error');
      this._msg.showAPIError(error);
      console.log('after show error');
    });
  }
}
