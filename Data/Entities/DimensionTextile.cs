using System;
using System.Collections.Generic;

namespace Group1_5_FagelGamous.Data.Entities
{
    public partial class DimensionTextile
    {
        public long MainDimensionid { get; set; }
        public long MainTextileid { get; set; }

        public virtual Textile? Textiles { get; set; }
        public virtual Dimension? Dimensions { get; set; }
    }
}
