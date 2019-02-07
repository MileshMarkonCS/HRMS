using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.Misc
{
    public class SelectViewModel
    {
    }

    [NotMapped]
    public class SelectDdl
    {
        [Key]
        public Int64 Id { get; set; }
        public string Name { get; set; }
    }
    [NotMapped]
    public class SelectDdlParameters
    {
        public string TableName { get; set; }
        public string DisplayColumnName { get; set; }
        public string IndexColumnName { get; set; }
        public string WhereClause { get; set; }
        public string OrderByClause { get; set; }
        public Boolean NoneRecord { get; set; }
    }

}
