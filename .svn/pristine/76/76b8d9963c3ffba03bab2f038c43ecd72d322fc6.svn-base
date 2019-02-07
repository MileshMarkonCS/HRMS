using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.Misc
{
    public class MenuViewModel
    {
    }

    [NotMapped]
    public class SpMenus
    {
        [Key]

        [Required]
        [Display(Name = "MenuId")]
        public Int64 MenuId { get; set; }

        [Required]
        [Display(Name = "ParentMenuId")]
        public Int64 ParentMenuId { get; set; }

        [Required]
        [Display(Name = "MenuTypeId")]
        public Int64 MenuTypeId { get; set; }

        [Required]
        [Display(Name = "MenuText")]
        public string MenuText { get; set; }

        [Display(Name = "Controller Name")]
        public string ControllerName { get; set; }

        [Display(Name = "Action Name")]
        public string ActionName { get; set; }

        [Display(Name = "CSS Class Name")]
        public string CSSClassName { get; set; }

        [Required]
        [Display(Name = "Menu Bullet")]
        public string MenuBullet { get; set; }

        [Required]
        [Display(Name = "Menu Order")]
        public Int64 MenuOrder { get; set; }

        [Required]
        [Display(Name = "Menu Level")]
        public Int64 MenuLevel { get; set; }

        [Required]
        [Display(Name = "Menu Icon")]
        public string MenuIcon { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }
        
    }

    [NotMapped]
    public class NavItem
    {
        [Key]
        public Int64 NavId { get; set; }
        public string DisplayName { get; set; }
        public Boolean Disabled { get; set; }
        public string IconName { get; set; }
        public string RouteName { get; set; }
        public List<NavItem> Children { get; set; }
        public Boolean IsParent { get; set; }

    }

    [NotMapped]
    public class ScreenRight
    {
        [Key]
        public Boolean ViewFlag { get; set; }
        public Boolean CreateFlag { get; set; }
        public Boolean EditFlag { get; set; }
        public Boolean DeleteFlag { get; set; }
        public Boolean ExportFlag { get; set; }
        public Boolean AmendFlag { get; set; }
        public Boolean ReverseFlag { get; set; }
        public Boolean ShortCloseFlag { get; set; }
        public Boolean PrintFlag { get; set; }
    }

}
