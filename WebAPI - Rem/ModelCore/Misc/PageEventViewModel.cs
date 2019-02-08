using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.Misc
{
    public class PageEventViewModel
    {
    }

    [NotMapped]
    public class PageSortEntry
    {
        [Key]
        [Required]        [Display(Name = "Page Columns")]        public Int64 PageColumnsId { get; set; }

        [Required]        [Display(Name = "User")]        public Int64 UserId { get; set; }

        [Required]        [Display(Name = "User Name")]        public string UserName { get; set; }

        [Required]        [Display(Name = "Table")]        public Int64 TableId { get; set; }

        [Required]        [Display(Name = "Table")]        public string Table { get; set; }

        [Required]        [Display(Name = "Column")]        public Int64 ColumnId { get; set; }

        [Required]        [Display(Name = "Column")]        public bool Column { get; set; }

        [Required]        [Display(Name = "Order No.")]        public int OrderNo { get; set; }

        [Required]        [Display(Name = "Sort Order No.")]        public int SortOrderNo { get; set; }

        [Required]        [Display(Name = "Direction")]        public Int64 SortDirectionId { get; set; }

        [Required]        [Display(Name = "Direction")]        public string SortDirection { get; set; }

        [Required]        [Display(Name = "Display Column")]        public bool DisplayColumn { get; set; }

        public bool Deleted { get; set; }

    }

    [NotMapped]
    public class PageSortIndex
    {
        [Key]
        [Required]        [Display(Name = "Page Columns")]        public Int64 PageColumnsId { get; set; }

        [Required]        [Display(Name = "User")]        public Int64 UserId { get; set; }

        [Required]        [Display(Name = "User Name")]        public string UserName { get; set; }

        [Required]        [Display(Name = "Table")]        public Int64 TableId { get; set; }

        [Required]        [Display(Name = "Table")]        public string Table { get; set; }

        [Required]        [Display(Name = "Column")]        public Int64 ColumnId { get; set; }

        [Required]        [Display(Name = "Column")]        public bool Column { get; set; }

        [Required]        [Display(Name = "Order No.")]        public int OrderNo { get; set; }

        [Required]        [Display(Name = "Sort Order No.")]        public int SortOrderNo { get; set; }

        [Required]        [Display(Name = "Direction")]        public Int64 SortDirectionId { get; set; }

        [Required]        [Display(Name = "Direction")]        public string SortDirection { get; set; }

        [Required]        [Display(Name = "Display Column")]        public bool DisplayColumn { get; set; }
    }

}
