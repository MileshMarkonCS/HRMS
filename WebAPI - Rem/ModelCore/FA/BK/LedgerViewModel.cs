using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.FA.BK
{
    public class LedgerViewModel
    {
    }

    [NotMapped]
    public class LedgerIndex
    {
        [Key]
        [Required]
        [Display(Name = "Ledger Id")]
        public Int64 LedgerId { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string LedgerCode { get; set; }

        [Required]
        [Display(Name = "Ledger")]
        public string Ledger { get; set; }

        [Required]
        [Display(Name = "Ledger Group")]
        public bool LedgerGroupFlag { get; set; }

        [Required]
        [Display(Name = "Ledger Group")]
        public Int64 LedgerGroupId { get; set; }

        [Required]
        [Display(Name = "Ledger Group")]
        public string LedgerGroup { get; set; }

        [Required]
        [Display(Name = "Main Ledger Group")]
        public Int64 MainLedgerGroupId { get; set; }

        [Required]
        [Display(Name = "Main Ledger Group")]
        public string MainLedgerGroup { get; set; }

        [Required]
        [Display(Name = "Ledger Type")]
        public Int64 LedgerTypeId { get; set; }

        [Required]
        [Display(Name = "Ledger Type")]
        public string LedgerType { get; set; }


        [Required]
        [Display(Name = "Control Account")]
        public Int64 ControlAccountId { get; set; }

        [Required]
        [Display(Name = "Control Account")]
        public string ControlAccount { get; set; }


        [Required]
        [Display(Name = "No JV Posting")]
        public bool NoJVPosting { get; set; }

        [Required]
        [Display(Name = "Automatic Posting")]
        public Int64 AutomaticPostingId { get; set; }

        [Required]
        [Display(Name = "Automatic Posting")]
        public string AutomaticPosting { get; set; }

        [Required]
        [Display(Name = "Currency")]
        public Int64 CurrencyId { get; set; }

        [Required]
        [Display(Name = "Currency")]
        public string Currency { get; set; }

        [Required]
        [Display(Name = "Level No.")]
        public Int64 LevelNo { get; set; }

        [Required]
        [Display(Name = "Effective From")]
        public DateTime EffectiveFrom { get; set; }

        [Required]
        [Display(Name = "Effective To")]
        public DateTime EffectiveTo { get; set; }

        [Required]
        [Display(Name = "Analysis Code Applicable")]
        public bool AnalysisCodeApplicableFlag { get; set; }

        [Required]
        [Display(Name = "Cost Center Application")]
        public bool CostCenterApplication { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        public Int64 TotalPages { get; set; }
        public Int64 TotalRecords { get; set; }

    }

    [NotMapped]
    public class LedgerEntry
    {
        [Key]
        [Required]
        [Display(Name = "Ledger ID")]
        public Int64 LedgerId { get; set; }

        [Required]
        [Display(Name = "Ledger Code")]
        public string LedgerCode { get; set; }

        [Required]
        [Display(Name = "Ledger")]
        public string Ledger { get; set; }

        [Required]
        [Display(Name = "Ledger Group")]
        public bool LedgerGroupFlag { get; set; }

        [Required]
        [Display(Name = "Ledger Group")]
        public Int64 LedgerGroupId { get; set; }

        [Required]
        [Display(Name = "Main Ledger Group")]
        public Int64 MainLedgerGroupId { get; set; }

        [Required]
        [Display(Name = "Ledger Type")]
        public Int64 LedgerTypeId { get; set; }

        [Required]
        [Display(Name = "Control Account")]
        public Int64 ControlAccountId { get; set; }

        [Required]
        [Display(Name = "No JV Posting")]
        public bool NoJVPosting { get; set; }

        [Required]
        [Display(Name = "Automatic Posting")]
        public Int64 AutomaticPostingId { get; set; }

        [Required]
        [Display(Name = "Currency")]
        public Int64 CurrencyId { get; set; }

        [Required]
        [Display(Name = "Level No.")]
        public Int64 LevelNo { get; set; }

        [Required]
        [Display(Name = "Effective From")]
        public DateTime EffectiveFrom { get; set; }

        [Required]
        [Display(Name = "Effective To")]
        public DateTime EffectiveTo { get; set; }

        [Required]
        [Display(Name = "Analysis Code Applicable")]
        public bool AnalysisCodeApplicableFlag { get; set; }

        [Required]
        [Display(Name = "Cost Center Application")]
        public bool CostCenterApplication { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        public AuditColumns AuditColumns { get; set; }
    }

}
