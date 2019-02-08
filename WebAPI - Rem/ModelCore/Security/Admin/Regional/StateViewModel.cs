﻿using ModelCore.Misc;
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

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        public Int64 TotalPages { get; set; }
        public Int64 TotalRecords { get; set; }

    }


    [NotMapped]
    public class StateEntry
    {
        [Key]
        [Display(Name = "State Id")]

        [Required]
        [Display(Name = "State Code")]

        [Required]
        [Display(Name = "State")]

        [Required]
        [Display(Name = "Country")]

        [Required]
        [Display(Name = "Active")]

        [Required]
        public AuditColumns AuditColumns { get; set; }
    }

}