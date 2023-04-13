using System;
using System.Collections.Generic;

namespace Group1_5_FagelGamous.Data.Entities
{
    public partial class Burialmain
    {
        public Burialmain(int id, string? squarenorthsouth, string? headdirection, string? sex, string? northsouth,
                      string? depth, string? eastwest, string? adultsubadult, string? facebundles, string? southtohead,
                      string? preservation, string? fieldbookpage, string? squareeastwest, string? goods, string? text,
                      string? wrapping, string? haircolor, string? westtohead, string? samplescollected, string? area,
                      string? burialid, string? length, string? burialnumber, string? dataexpertinitials,
                      string? westtofeet, string? ageatdeath, string? southtofeet, string? excavationrecorder,
                      string? photos, string? hair, string? burialmaterials, DateTime? dateofexcavation,
                      string? fieldbookexcavationyear, string? clusternumber, string? shaftnumber)
        {
            Id = id;
            Squarenorthsouth = squarenorthsouth;
            Headdirection = headdirection;
            Sex = sex;
            Northsouth = northsouth;
            Depth = depth;
            Eastwest = eastwest;
            Adultsubadult = adultsubadult;
            Facebundles = facebundles;
            Southtohead = southtohead;
            Preservation = preservation;
            Fieldbookpage = fieldbookpage;
            Squareeastwest = squareeastwest;
            Goods = goods;
            Text = text;
            Wrapping = wrapping;
            Haircolor = haircolor;
            Westtohead = westtohead;
            Samplescollected = samplescollected;
            Area = area;
            Burialid = burialid;
            Length = length;
            Burialnumber = burialnumber;
            Dataexpertinitials = dataexpertinitials;
            Westtofeet = westtofeet;
            Ageatdeath = ageatdeath;
            Southtofeet = southtofeet;
            Excavationrecorder = excavationrecorder;
            Photos = photos;
            Hair = hair;
            Burialmaterials = burialmaterials;
            Dateofexcavation = dateofexcavation;
            Fieldbookexcavationyear = fieldbookexcavationyear;
            Clusternumber = clusternumber;
            Shaftnumber = shaftnumber;
            MainTextiles = new HashSet<Textile>();
        }


        public int Id { get; set; }
        public string? Squarenorthsouth { get; set; }
        public string? Headdirection { get; set; }
        public string? Sex { get; set; }
        public string? Northsouth { get; set; }
        public string? Depth { get; set; }
        public string? Eastwest { get; set; }
        public string? Adultsubadult { get; set; }
        public string? Facebundles { get; set; }
        public string? Southtohead { get; set; }
        public string? Preservation { get; set; }
        public string? Fieldbookpage { get; set; }
        public string? Squareeastwest { get; set; }
        public string? Goods { get; set; }
        public string? Text { get; set; }
        public string? Wrapping { get; set; }
        public string? Haircolor { get; set; }
        public string? Westtohead { get; set; }
        public string? Samplescollected { get; set; }
        public string? Area { get; set; }
        public string? Burialid { get; set; }
        public string? Length { get; set; }
        public string? Burialnumber { get; set; }
        public string? Dataexpertinitials { get; set; }
        public string? Westtofeet { get; set; }
        public string? Ageatdeath { get; set; }
        public string? Southtofeet { get; set; }
        public string? Excavationrecorder { get; set; }
        public string? Photos { get; set; }
        public string? Hair { get; set; }
        public string? Burialmaterials { get; set; }
        public DateTime? Dateofexcavation { get; set; }
        public string? Fieldbookexcavationyear { get; set; }
        public string? Clusternumber { get; set; }
        public string? Shaftnumber { get; set; }

        public virtual ICollection<Textile> MainTextiles { get; set; }


    }
}
