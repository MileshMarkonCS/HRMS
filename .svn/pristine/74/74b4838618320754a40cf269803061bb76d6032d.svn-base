using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.Misc
{
    [NotMapped]
    public class SQLResult
    {
        [Key]
        [Display(Name = "ID")]
        public Int64 ID { get; set; }

        [Display(Name = "Error No.")]
        public Int64 ErrorNo { get; set; }

        [Display(Name = "Error Message")]
        public string ErrorMessage { get; set; }

        [Display(Name = "Document No.")]
        public string DocumentNo { get; set; }

        [Display(Name = "SQL Error No.")]
        public int SQLErrorNumber { get; set; }

        [Display(Name = "SQL Severity")]
        public int SQLErrorSeverity { get; set; }

        [Display(Name = "SQL State")]
        public int SQLErrorState { get; set; }

        [Display(Name = "SQL Object Name")]
        public string SQLObjectName { get; set; }

        [Display(Name = "Line No.")]
        public int SQLErrorLineNo { get; set; }

        [Display(Name = "SQL Error Message")]
        public string SQLErrorMessage { get; set; }
    }
}
