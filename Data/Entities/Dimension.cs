using System;
using System.Collections.Generic;

namespace Group1_5_FagelGamous.Data.Entities
{
    public partial class Dimension
    {
        public Dimension()
        {
            MainTextiles = new HashSet<Textile>();
        }

        public int Id { get; set; }
        public string? Dimensiontype { get; set; }
        public string? Value { get; set; }
        public int? Dimensionid { get; set; }

        public virtual ICollection<Textile> MainTextiles { get; set; }
    }
}
