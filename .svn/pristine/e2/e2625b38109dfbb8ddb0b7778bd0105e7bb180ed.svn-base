using System;
using System.Collections.Generic;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class MThrmschecklistItems
    {
        public MThrmschecklistItems()
        {
            MThrmsinterviewChecklistEvaluationDetails = new HashSet<MThrmsinterviewChecklistEvaluationDetails>();
        }

        public long MThrmschecklistItemsId { get; set; }
        public string Name { get; set; }
        public decimal? ScoreFrom { get; set; }
        public decimal? ScoreTo { get; set; }

        public ICollection<MThrmsinterviewChecklistEvaluationDetails> MThrmsinterviewChecklistEvaluationDetails { get; set; }
    }
}
