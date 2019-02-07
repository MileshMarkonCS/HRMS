using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.Security.User
{
    public class UserViewModel
    {
    }

    [NotMapped]
    public class UserIndex
    {
        [Key]
        [Required]
        [Display(Name = "User Id")]
        public Int64 UserId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Role Id")]
        public Int64 RoleId { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }
    }

    [NotMapped]
    public class Login
    {
        [Required]
        [Display(Name = "User Name")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    [NotMapped]
    public class SignUp
    {
        [Required]
        [Display(Name = "User Name")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Mobile No.")]
        [DataType(DataType.PhoneNumber)]
        public Int64 MobileNo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "News Letter")]
        public bool NewsLetter { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string EmailVerificationKey { get; set; }
        public string MobileNoVerificationKey { get; set; }
        public string PasswordResetKey { get; set; }
    }

    [NotMapped]
    public class VerifyUser
    {
        [Required]
        [Display(Name = "User Name")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Username { get; set; }

    }

    [NotMapped]
    public class SignInUserProfile
    {
        [Key]
        public Int64 UserId { get; set; }
        public string UserName { get; set; }
        public Int64 MobileNo { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string EmailVerificationKey { get; set; }
        public string MobileNoVerificationKey { get; set; }
        public string Password { get; set; }
        //public string ConfirmPassword { get; set; }
        public string PasswordResetKey { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Int64 OperationCompanyId { get; set; }
        public string OperationCompany { get; set; }
        //public Int64 OperationDivisionId { get; set; }
        //public string OperationDivision { get; set; }
        public Int64 DepartmentId { get; set; }
        public string Department { get; set; }
        public Int64 DesignationId { get; set; }
        public string Designation { get; set; }
        //public Int64 UnitId { get; set; }
        //public string UnitName { get; set; }
        public Int64 EmployeeId { get; set; }
        public string Employee { get; set; }
        public bool Active { get; set; }
        public Int64 CompanyId { get; set; }
        public string CompayTitle { get; set; }
        public string Token { get; set; }
    }

    [NotMapped]
    public class ResendVerificationKey
    {
        [Key]
        public Int64 UserId { get; set; }
        public string UserName { get; set; }
        public Int64 MobileNo { get; set; }
        public string EmailVerificationKey { get; set; }
        public string MobileNoVerificationKey { get; set; }
        public string Password { get; set; }
        public string PasswordResetKey { get; set; }
        public bool Active { get; set; }
    }

    [NotMapped]
    public class UserProfile
    {
        [Key]
        public Int64 UserId { get; set; }
        public string UserName { get; set; }
        public Boolean EmailVerified { get; set; }
        public Int64 MobileNo { get; set; }
        public Boolean MobileVerified { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PINCode { get; set; }
        public Int64 CountryId { get; set; }
        public string Country { get; set; }
        public Int64 StateId { get; set; }
        public string State { get; set; }
        public Int64 CityId { get; set; }
        public string City { get; set; }
        public Int64 OperationCompanyId { get; set; }
        public string OperationCompany { get; set; }
        public Int64 OperationDivisionId { get; set; }
        public string OperationDivision { get; set; }
        public Int64 DepartmentId { get; set; }
        public string Department { get; set; }
        public Int64 DesignationId { get; set; }
        public string Designation { get; set; }
        public Int64 UnitId { get; set; }
        public string UnitName { get; set; }
        public Int64 EmployeeId { get; set; }
        public string Employee { get; set; }
        public Int64 CompanyId { get; set; }
        public string CompayTitle { get; set; }
        public bool Active { get; set; }

    }

    [NotMapped]
    public class EmailMobileVerify
    {
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Display(Name = "Mobile No.")]
        public Int64 MobileNo { get; set; }

        [Display(Name = "Email Verification Key")]
        public string EmailVerificationKey { get; set; }

        [Display(Name = "Mobile Verification Key")]
        public string MobileNoVerificationKey { get; set; }
    }

    [NotMapped]
    public class UserMenus
    {
        [Key]

        [Required]
        [Display(Name = "MenuId")]
        public Int64 MenuId { get; set; }

        [Required]
        [Display(Name = "ParentMenuId")]
        public Int64 ParentMenuId { get; set; }

        [Required]
        [Display(Name = "MenuTypeId")]
        public Int64 MenuTypeId { get; set; }

        [Required]
        [Display(Name = "MenuText")]
        public string MenuText { get; set; }

        [Display(Name = "ControllerName")]
        public string ControllerName { get; set; }

        [Display(Name = "ActionName")]
        public string ActionName { get; set; }

        [Display(Name = "CSSClassName")]
        public string CSSClassName { get; set; }

        [Required]
        [Display(Name = "MenuBullet")]
        public string MenuBullet { get; set; }

        [Required]
        [Display(Name = "MenuOrder")]
        public Int64 MenuOrder { get; set; }

        [Required]
        [Display(Name = "MenuLevel")]
        public Int64 MenuLevel { get; set; }

        [Required]
        [Display(Name = "MenuIcon")]
        public string MenuIcon { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }
    }

    [NotMapped]
    public class ChangePassword
    {
        [Key]
        [Required]
        public Int64 UserId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
