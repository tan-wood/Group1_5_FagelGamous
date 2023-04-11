using System;
using System.Collections.Generic;

namespace Group1_5_FagelGamous.Data.Entities
{
    public partial class AnalysisTextile
    {
        public long MainAnalysisid { get; set; }
        public long MainTextileid { get; set; }
        public virtual Textile? Textiles { get; set; }
        public virtual Analysis? Analysis { get; set; }
    }
}
