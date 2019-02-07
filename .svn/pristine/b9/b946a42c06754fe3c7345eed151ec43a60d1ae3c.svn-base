using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.FA.BK.Master
{
    public class CurrencyViewModel
    {
    }

    [NotMapped]
    public class CurrencyIndex
    {
        [Key]
        [Required]        [Display(Name = "Currency Id")]        public Int64 CurrencyId { get; set; }

        [Required]        [Display(Name = "Code")]        public string CurrencyCode { get; set; }

        [Required]        [Display(Name = "Currency")]        public string Currency { get; set; }

        [Required]        [Display(Name = "Description")]        public string Description { get; set; }

        [Required]        [Display(Name = "Symbol")]        public string CurrencySymbol { get; set; }

        [Required]        [Display(Name = "Active")]        public bool Active { get; set; }

        public Int64 TotalPages { get; set; }
        public Int64 TotalRecords { get; set; }


    }

    [NotMapped]
    public class CurrencyEntry
    {
        [Key]
        [Required]        [Display(Name = "Currency Id")]        public Int64 CurrencyId { get; set; }

        [Required]        [Display(Name = "Code")]        public string CurrencyCode { get; set; }

        [Required]        [Display(Name = "Currency")]        public string Currency { get; set; }

        [Required]        [Display(Name = "Description")]        public string Description { get; set; }

        [Required]        [Display(Name = "Symbol")]        public string CurrencySymbol { get; set; }

        [Required]        [Display(Name = "Active")]        public bool Active { get; set; }

        [Required]
        public AuditColumns AuditColumns { get; set; }

    }


}
