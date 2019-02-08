using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.Security.Admin.Regional
{
    public class CountryViewModel
    {
    }

    [NotMapped]
    public class CountryIndex
    {
        [Key]
        [Required]
        [Display(Name = "Country entry")]
        public Int64 CountryId { get; set; }

        [Required]
        [Display(Name = "Country code")]
        public string CountryCode { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "ISO Alpha 2 Code")]
        public string ISOAlpha2Code { get; set; }

        [Required]
        [Display(Name = "ISO Alpha 3 Code")]
        public string ISOAlpha3Code { get; set; }

        [Required]
        [Display(Name = "ISO Numeric Code")]
        public string ISONumericCode { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        public Int64 TotalPages { get; set; }
        public Int64 TotalRecords { get; set; }
    }

    [NotMapped]
    public class CountryEntry
    {
        [Key]
        [Required]
        [Display(Name = "Country entry")]
        public Int64 CountryId { get; set; }

        [Required]
        [Display(Name = "Country code")]
        public string CountryCode { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "ISO Alpha 2 Code")]
        public string ISOAlpha2Code { get; set; }

        [Required]
        [Display(Name = "ISO Alpha 3 Code")]
        public string ISOAlpha3Code { get; set; }

        [Required]
        [Display(Name = "ISO Numeric Code")]
        public string ISONumericCode { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Audit Columns")]
        public AuditColumns AuditColumns { get; set; }
    }

}
