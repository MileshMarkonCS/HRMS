export class ChangePasswordModel {
    constructor(
        public userid: number,
        public username: string,
        public password: string,
        public confirmpassword: string
    ) { }
}
