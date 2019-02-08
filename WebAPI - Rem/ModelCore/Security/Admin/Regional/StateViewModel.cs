using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.Security.Admin.Regional
{
    public class StateViewModel
    {
    }

    [NotMapped]
    public class StateIndex
    {
        [Key]

        [Required]        [Display(Name = "State Id")]        public Int64 StateId { get; set; }

        [Required]        [Display(Name = "State Code")]        public string StateCode { get; set; }

        [Required]        [Display(Name = "State")]        public string STATE { get; set; }

        [Required]        [Display(Name = "Country Id")]        public Int64 CountryId { get; set; }

        [Required]        [Display(Name = "Country Code")]        public string CountryCode { get; set; }

        [Required]        [Display(Name = "Country")]        public string Country { get; set; }

        [Required]        [Display(Name = "Active")]        public bool Active { get; set; }

        public Int64 TotalPages { get; set; }
        public Int64 TotalRecords { get; set; }

    }


    [NotMapped]
    public class StateEntry
    {
        [Key]
        [Display(Name = "State Id")]        public Int64 StateId { get; set; }

        [Required]
        [Display(Name = "State Code")]        public string StateCode { get; set; }

        [Required]
        [Display(Name = "State")]        public string State { get; set; }

        [Required]
        [Display(Name = "Country")]        public Int64 CountryId { get; set; }

        [Required]
        [Display(Name = "Active")]        public bool Active { get; set; }

        [Required]
        public AuditColumns AuditColumns { get; set; }
    }

}
