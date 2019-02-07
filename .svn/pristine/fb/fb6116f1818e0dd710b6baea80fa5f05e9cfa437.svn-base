using ModelCore.Misc;
using ModelCore.Security.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceCore
{
    public interface IUser
    {
        Task<bool> UserExists(string _username);
        Task<SignInUserProfile> GetUserProfileAsync(string _username);
        Task<UserProfile> GetUserProfileWithIdAsync(Int64 pUserId);
        Task<SQLResult> ChangePassword(ChangePassword pModel, AuditColumns pAuditColumns);
        Task<SignInUserProfile> Login(string _username);

        //Task<List<UserIndex>> GetIndex();
        //Task<UserIndex> GetEntry(Int64 id);
        //Task<SignInUserProfile> SignIn(string _username);
        //Task<SQLResult> UserSignUp(SignUp pModel, AuditColumns pAuditColumns);
        //Task<ResendVerificationKey> ResendVerificationKey(string _username);
        //Task<SQLResult> VerifyEmailAndMobile(EmailMobileVerify pModel);
        //Task<List<UserMenus>> GetMenus(Int64 pUserId);
        //Task<List<UserMenus>> GetNav(Int64 pUserId);


    }
}
