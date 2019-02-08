﻿using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public class HRMSRolesResponsibility
    {       
    }

    [NotMapped]
    public class HRMSRolesResponsibilityIndex
    {
        [Key]
        [Required]

        [Display(Name = "ResponsibilityName")]

        [Display(Name = "Description")]

        [Display(Name = "Active")]

        public Int64 TotalPages { get; set; }
        public Int64 TotalRecords { get; set; }
    }

    [NotMapped]
    public class HRMSRolesResponsibilityEntry
    {
        [Key]
        [Required]

        [Display(Name = "ResponsibilityName")]

        [Display(Name = "Description")]

        [Display(Name = "Active")]

        [Required]
        public AuditColumns AuditColumns { get; set; }
    }

}