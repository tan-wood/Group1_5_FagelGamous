using System;
using System.Collections.Generic;

namespace Group1_5_FagelGamous.Data.Entities
{
    public partial class Textilefunction
    {
        public Textilefunction()
        {
            MainTextiles = new HashSet<Textile>();
        }

        public long Id { get; set; }
        public string? Value { get; set; }
        public int? Textilefunctionid { get; set; }

        public virtual ICollection<Textile> MainTextiles { get; set; }
    }
}
