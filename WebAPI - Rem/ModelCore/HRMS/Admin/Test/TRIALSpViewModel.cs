using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.HRMS.Admin.Test
{
    public class TRIALSpViewModel
    {
    }

    [NotMapped]
    public class TRIALSpIndex
    {
        [Key]
        [Required]
        [Display(Name = "TRIALSp entry")]
        public Int64 TRIALSpId { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        public Int64 TotalPages { get; set; }
        public Int64 TotalRecords { get; set; }
        
        
    }


    [NotMapped]
    public class TRIALSpEntry
    {
        [Key]
        [Required]
        [Display(Name = "TRIALSp entry")]
        public Int64 TRIALSpId { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Audit Columns")]
        public AuditColumns AuditColumns { get; set; }
        
        
    }



}