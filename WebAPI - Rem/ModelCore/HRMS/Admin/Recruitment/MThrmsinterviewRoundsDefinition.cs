using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmsinterviewRoundsDefinition
    {
        public MThrmsinterviewRoundsDefinition()
        {
            MThrmsinterviewScheduleRounds = new HashSet<MThrmsinterviewScheduleRounds>();
        }

        public long MThrmsinterviewRoundsDefinitionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<MThrmsinterviewScheduleRounds> MThrmsinterviewScheduleRounds { get; set; }
    }
}
