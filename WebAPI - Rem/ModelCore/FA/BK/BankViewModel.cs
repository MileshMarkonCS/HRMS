﻿using ModelCore.Misc;
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
        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        public Int64 TotalPages { get; set; }
        public Int64 TotalRecords { get; set; }

    }

    [NotMapped]
    public class BankEntry
    {
        [Key]
        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]
        public List<BankDetailEntry> BankDetailEntry { get; set; }

        [Required]
        [Display(Name = "Audit Columns")]
        public AuditColumns AuditColumns { get; set; }

    }


    public class BankDetailEntry
    {
        [Key]

        [Required]

        [Required]

        [Display(Name = "Bank Code")]

        [Display(Name = "Description")]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]

        [Required]
    }

}