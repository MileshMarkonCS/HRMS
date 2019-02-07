import { AuditModel } from 'src/app/components/misc/AuditParams.Model';

export class CurrencyModel {
    constructor(
        public currencyId: number,
        public currencyCode: string,
        public currency: string,
        public description: string,
        public currencySymbol: string,
        public active: boolean,
        public auditColumns: AuditModel,
        public entryMode: string,
        public readOnly: boolean
    ) { }
}
