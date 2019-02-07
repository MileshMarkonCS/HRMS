import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UIService } from 'src/app/components/shared/uiservices/UI.service';
import { MessageBoxService } from 'src/app/components/messagebox/message-box.service';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { UserModule } from '../../user/user.model';
import { LoginModule } from './login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  pModel: LoginModule;

  constructor(
    private _ui: UIService,
    private _msg: MessageBoxService,
    private _auth: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  submit(form: NgForm) {
    this._ui.loadingStateChanged.next(true);
    if (form.invalid) {
      this._msg.FillRequired();
      this._ui.loadingStateChanged.next(false);
      return false;
    }
    if (this.validateForm(form) !== true) {
      this._ui.loadingStateChanged.next(false);
      return false;
    }
    try {
      this._auth.login(form.value).subscribe((data: UserModule) => {
        if (data !== null) {
          this._ui.loadingStateChanged.next(false);
          this.router.navigate(['/dashboard']);
          return true;
        } else {
          this._ui.loadingStateChanged.next(false);
          this._msg.showError('Unable to login!');
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
  }

  validateForm(form: NgForm) {
    if (form.value.username === '' || form.value.username === null) {
      this._msg.blank('Email address');
      return false;
    }
    if (form.value.password === '' || form.value.password === null) {
      this._msg.blank('Password');
      return false;
    }

    return true;
  }

}
