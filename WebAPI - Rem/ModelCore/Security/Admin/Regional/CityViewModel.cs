using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.Security.Admin.Regional
{
    public class CityViewModel
    {
    }

    [NotMapped]
    public class CityIndex
    {
        [Key]

        [Required]
        [Display(Name = "City Id")]
        public Int64 CityId { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string CityCode { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State Id")]
        public Int64 StateId { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Counrty Id")]
        public Int64 CountryId { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        public Int64 TotalPages { get; set; }
        public Int64 TotalRecords { get; set; }
    }

    [NotMapped]
    public class CityEntry
    {
        [Key]

        [Required]
        [Display(Name = "City Id")]
        public Int64 CityId { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string CityCode { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Country Id")]
        public Int64 CountryId { get; set; }

        [Required]
        [Display(Name = "State Id")]
        public Int64 StateId { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Audit Columns")]
        public AuditColumns AuditColumns { get; set; }
    }

}
