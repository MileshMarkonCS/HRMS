using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.FA.BK
{
    public class BankViewModel
    {
    }

    [NotMapped]
    public class BankIndex
    {
        [Key]
        [Required]        [Display(Name = "Bank Id")]        public Int64 BankId { get; set; }

        [Required]        [Display(Name = "Bank")]        public string Bank { get; set; }

        [Required]        [Display(Name = "Bank Reference No.")]        public string BankReferenceNo { get; set; }

        [Required]        [Display(Name = "Bank Clearing No.")]        public string BankClearingNo { get; set; }

        [Required]        [Display(Name = "Cash Account")]        public bool CashAccount { get; set; }

        public Int64 TotalPages { get; set; }
        public Int64 TotalRecords { get; set; }

    }

    [NotMapped]
    public class BankEntry
    {
        [Key]
        [Required]        [Display(Name = "Bank Id")]        public Int64 BankId { get; set; }

        [Required]        [Display(Name = "Bank")]        public string Bank { get; set; }

        [Required]        [Display(Name = "Bank Reference No.")]        public string BankReferenceNo { get; set; }

        [Required]        [Display(Name = "Bank Clearing No.")]        public string BankClearingNo { get; set; }

        [Required]        [Display(Name = "Cash Account")]        public bool CashAccount { get; set; }

        [Required]        [Display(Name = "Bank Detail Entry")]
        public List<BankDetailEntry> BankDetailEntry { get; set; }

        [Required]
        [Display(Name = "Audit Columns")]
        public AuditColumns AuditColumns { get; set; }

    }


    public class BankDetailEntry
    {
        [Key]

        [Required]        [Display(Name = "Bank Detail Id")]        public Int64 BankDetailId { get; set; }

        [Required]        [Display(Name = "Bank Id")]        public Int64 BankId { get; set; }

        [Display(Name = "Bank Code")]        public string BankCode { get; set; }

        [Display(Name = "Description")]        public string Description { get; set; }

        [Required]        [Display(Name = "Account Type")]        public Int64 AccountTypeId { get; set; }

        [Required]        [Display(Name = "Account No.")]        public string AccountNo { get; set; }

        [Required]        [Display(Name = "Currency")]        public Int64 CurrencyId { get; set; }

        [Required]        [Display(Name = "Credit Limit")]        public decimal CreditLimit { get; set; }

        [Required]        [Display(Name = "Overdraft Amount")]        public decimal OverdraftAmount { get; set; }

        [Required]        [Display(Name = "IFSC Code")]        public string IFSCCode { get; set; }

        [Required]        [Display(Name = "Swift Code")]        public string SwiftCode { get; set; }

        [Required]        [Display(Name = "MICR Code")]        public string MICRCode { get; set; }

        [Required]        [Display(Name = "IBAN")]        public string IBAN { get; set; }

        [Required]        [Display(Name = "Account Balance")]        public decimal AccountBalance { get; set; }

        [Required]        [Display(Name = "Account Balance Dr / Cr")]        public Int64 AccountBalanceDrCrId { get; set; }

        [Required]        [Display(Name = "Opening Reconcilation")]        public decimal OpeningReconcilation { get; set; }

        [Required]        [Display(Name = "Opening Reconcilation Dr / Cr")]        public Int64 OpeningReconcilationDrCrId { get; set; }

        [Required]        [Display(Name = "Cash Account")]        public bool CashAccount { get; set; }

        [Required]        [Display(Name = "Active")]        public bool Active { get; set; }

        [Required]        [Display(Name = "Company")]        public Int64 CompanyId { get; set; }

        [Required]        [Display(Name = "Branch")]        public Int64 BranchId { get; set; }

        [Required]        [Display(Name = "Financial Year")]        public Int64 FinancialYearId { get; set; }
    }

}
