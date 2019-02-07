import { Injectable } from '@angular/core';

@Injectable()
export class AppGlobals {
    readonly baseDomainUrl: string = 'localhost:4200';
    readonly baseAppUrl: string = 'http://localhost:4200/';

//    readonly baseAPIUrl: string = 'http://196.29.169.131:8080/api/';
    readonly baseAPIUrl: string = 'https://localhost:44377/api/';
//    readonly baseAPIUrl: string = 'http://172.168.0.137:8080/api/';

    readonly baseLandingAppUrl: string = 'http://localhost:4200/';
    readonly baseAppName: string = 'AMT.ERP';
    baseUserProfile: any;
}
