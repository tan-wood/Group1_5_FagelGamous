using System;
using System.Collections.Generic;

namespace Group1_5_FagelGamous.Data.Entities
{
    public partial class Decoration
    {
        public Decoration()
        {
            MainTextiles = new HashSet<Textile>();
        }

        public int Id { get; set; }
        public int? Decorationid { get; set; }
        public string? Value { get; set; }

        public virtual ICollection<Textile> MainTextiles { get; set; }
    }
}
