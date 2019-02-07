using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.Misc
{
    public class IDViewModel
    {
    }

    [NotMapped]
    public class IDModel
    {
        [Key]
        public Int64 ID { get; set; }
    }
}
