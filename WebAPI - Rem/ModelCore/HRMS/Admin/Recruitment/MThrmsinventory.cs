using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsinventory
    {
        public MThrmsinventory()
        {
            MThrmsdesignationInventory = new HashSet<MThrmsdesignationInventory>();
            MThrmsinventoryManagementDetails = new HashSet<MThrmsinventoryManagementDetails>();
        }

        public long MThrmsinventory1 { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<MThrmsdesignationInventory> MThrmsdesignationInventory { get; set; }
        public ICollection<MThrmsinventoryManagementDetails> MThrmsinventoryManagementDetails { get; set; }
    }
}
