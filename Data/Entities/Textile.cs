using System;
using System.Collections.Generic;

namespace Group1_5_FagelGamous.Data.Entities
{
    public partial class Textile
    {
        public Textile()
        {
            MainAnalyses = new HashSet<Analysis>();
            MainBurialmains = new HashSet<Burialmain>();
            MainColors = new HashSet<Color>();
            MainDecorations = new HashSet<Decoration>();
            MainDimensions = new HashSet<Dimension>();
            MainPhotodata = new HashSet<Photodatum>();
            MainStructures = new HashSet<Structure>();
            MainTextilefunctions = new HashSet<Textilefunction>();
            MainYarnmanipulations = new HashSet<Yarnmanipulation>();
        }

        public int Id { get; set; }
        public string? Locale { get; set; }
        public int? Textileid { get; set; }
        public string? Description { get; set; }
        public string? Burialnumber { get; set; }
        public string? Estimatedperiod { get; set; }
        public DateTime? Sampledate { get; set; }
        public DateTime? Photographeddate { get; set; }
        public string? Direction { get; set; }

        public virtual ICollection<Analysis> MainAnalyses { get; set; }
        public virtual ICollection<Burialmain> MainBurialmains { get; set; }
        public virtual ICollection<Color> MainColors { get; set; }
        public virtual ICollection<Decoration> MainDecorations { get; set; }
        public virtual ICollection<Dimension> MainDimensions { get; set; }
        public virtual ICollection<Photodatum> MainPhotodata { get; set; }
        public virtual ICollection<Structure> MainStructures { get; set; }
        public virtual ICollection<Textilefunction> MainTextilefunctions { get; set; }
        public virtual ICollection<Yarnmanipulation> MainYarnmanipulations { get; set; }
    }
}
