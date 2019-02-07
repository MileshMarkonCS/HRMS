using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Library
{
    public class Functions
    {


        public static List<NavItem> GenerateNav(List<NavItem> pNavs, List<SpMenus> pMenus, Int64 pParentMenuId)
        {
            foreach (SpMenus MenuItem in pMenus)
            {

                if (MenuItem.ParentMenuId == pParentMenuId)
                {
                    NavItem Item = new NavItem
                    {
                        NavId = MenuItem.MenuId,
                        Disabled = !MenuItem.Active,
                        DisplayName = MenuItem.MenuText,
                        IconName = MenuItem.MenuIcon,
                        RouteName = MenuItem.ActionName
                    };
                    if (MenuItem.MenuTypeId == 10001 || MenuItem.MenuTypeId == 10002)
                    {
                        Item.Children = GenerateNav(new List<NavItem>(), pMenus, MenuItem.MenuId);
                        Item.IsParent = true;
                    }
                    else
                    {
                        Item.Children = new List<NavItem>();
                        Item.IsParent = false;
                    }
                    pNavs.Add(Item);
                }
            }
            return pNavs;
        }

        public static SQLResult VerifyPasswordHash(string pPassword, byte[] pPasswordHash, byte[] pPasswordSalt)
        {
            SQLResult spres = new SQLResult
            {
                ErrorNo = 1,
                ErrorMessage = "Not processed!"
            };
            try
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512(pPasswordSalt))
                {
                    var ComputedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pPassword));
                    for (int i = 0; i < ComputedHash.Length; i++)
                    {
                        if (ComputedHash[i] != pPasswordHash[i])
                        {
                            spres.ErrorNo = 10001;
                            spres.ErrorMessage = "Invalid password!";
                            return spres;
                        }
                    }
                }
                spres.ErrorNo = 0;
                spres.ErrorMessage = "";
            }
            catch (Exception ex)
            {
                spres.ErrorNo = 9999999999;
                spres.ErrorMessage = ex.Message.ToString();
            }
            return spres;
        }

        public static string GenerateToken(Int64 pUserId, string pUserName, string pFirstName, IConfiguration _Config)
        {

            var mTokenHeadler = new JwtSecurityTokenHandler();
            var mKey = Encoding.ASCII.GetBytes(_Config.GetSection("AppSettings:Token").Value);
            var mTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, pUserId.ToString()),
                    new Claim(ClaimTypes.Name, pUserName),
                    new Claim(ClaimTypes.GivenName, pFirstName)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(mKey),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            SecurityToken mToken = mTokenHeadler.CreateToken(mTokenDescriptor);
            string mTokenString = mTokenHeadler.WriteToken(mToken);
            return mTokenString;
        }

        public static void CreatePasswordHash(string pPassword, out byte[] pPasswordHash, out byte[] pPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                pPasswordSalt = hmac.Key;
                pPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pPassword));
            }
        }

        public static SQLResult ValidateGetPageData(Int64 ScreenId, Int64 UserId, Int64 RecordsPerPage, Int64 PageNo, Int64 TableId, Boolean LastPage)
        {
            SQLResult result = new SQLResult
            {
                ErrorNo = 111111,
                ErrorMessage = "",
                DocumentNo = "",
                ID = 111111,
                SQLErrorLineNo = 0,
                SQLErrorMessage = "",
                SQLErrorNumber = 0,
                SQLErrorSeverity = 0,
                SQLErrorState = 0,
                SQLObjectName = ""
            };
            if (ScreenId <= 0)
            {
                result.ErrorMessage = Messages.Blank("Screen ID");
                return result;
            }
            if (UserId <= 0)
            {
                result.ErrorMessage = Messages.Blank("User ID");
                return result;
            }
            if (RecordsPerPage <= 0)
            {
                result.ErrorMessage = Messages.Blank("Records per page");
                return result;
            }
            if (PageNo <= 0)
            {
                result.ErrorMessage = Messages.Blank("Page number");
                return result;
            }
            if (TableId <= 0)
            {
                result.ErrorMessage = Messages.Blank("Table ID");
                return result;
            }
            result.ErrorNo = 0;
            result.ErrorMessage = "";
            result.DocumentNo = "";
            result.ID = 0;
            result.SQLErrorLineNo = 0;
            result.SQLErrorMessage = "";
            result.SQLErrorNumber = 0;
            result.SQLErrorSeverity = 0;
            result.SQLErrorState = 0;
            result.SQLObjectName = "";
            return result;
        }

    }
}
