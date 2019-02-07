export class UserModule {
    constructor(
        public userId: number,
        public userName: string,
        public mobileNo: string,
        public passwordHash: string[],
        public passwordSalt: string[],
        public emailVerificationKey: string,
        public mobileNoVerificationKey: string,
        public password: string,
        public passwordResetKey: string,
        public firstName: string,
        public middleName: string,
        public lastName: string,
        public operationCompanyId: number,
        public operationCompany: string,
        public departmentId: number,
        public department: string,
        public designationId: number,
        public designation: string,
        public active: Boolean,
        public companyId: number,
        public compayTitle: string,
        public token: string
) { }
}
