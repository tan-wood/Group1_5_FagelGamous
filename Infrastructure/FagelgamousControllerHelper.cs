using System.Text.Json.Serialization;
using System.Text.Json;
using Group1_5_FagelGamous.Data.Entities;
using Group1_5_FagelGamous.Data.UnitOfWork;
using Group1_5_FagelGamous.Data;

namespace Group1_5_FagelGamous.Infrastructure
{
    public class FagelgamousControllerHelper
    {
        private IUnitOfWork UOW { get; set; }

        public FagelgamousControllerHelper(IUnitOfWork uow)
        {
            UOW = uow;
        }
        
        /// <summary>
        /// Whenever your returning an object that was built with includes and thenincludes, you will use this function in order to have it return a correct json object
        /// </summary>
        /// <param name="stuff">This is your recently created var object returned from all the includes/thenincludes</param>
        /// <returns>It will return a dynamic object(var) to be stored in a variable named json </returns>
        public dynamic DeCyclifyYoCode(dynamic stuff)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            var json = JsonSerializer.Serialize(stuff, options);
            return json;
        }

        /// <summary>
        /// Either when you are creating a new Textile or updating it, you will use this method to do all the logic for it. 
        /// </summary>
        /// <param name="t">This is a single textile object. Regarless of whether you are updating or creating, it will just take the object as it is</param>
        /// <returns>This will return the Textile that has all the created and/or updated sub portions.</returns>
        public Textile TextileBuilder(Textile t)
        {
            if (t.MainColors != null)
            {
                List<Color> x = new();
                foreach (var color in t.MainColors)
                {
                    if(color.Id== 0)
                    {
                        var added = UOW.Color.Add(color);
                        x.Add(added);
                    }
                    else
                    {
                        UOW.Color.Update(color);
                        x.Add(color);
                    }
                    
                }
                t.MainColors = x;
            }
            if (t.MainDimensions != null)
            {
                List<Dimension> x = new();
                foreach (var dimension in t.MainDimensions)
                {
                    if (dimension.Id == 0)
                    {
                        var added = UOW.Dimension.Add(dimension);
                        x.Add(added);
                    }
                    else
                    {
                        UOW.Dimension.Update(dimension);
                        x.Add(dimension);
                    }
                }
                t.MainDimensions = x;
            }
            if (t.MainDecorations != null)
            {
                List<Decoration> x = new();
                foreach (var decoration in t.MainDecorations)
                {
                    if (decoration.Id == 0)
                    {
                        var added = UOW.Decoration.Add(decoration);
                        x.Add(added);
                    }
                    else
                    {
                        UOW.Decoration.Update(decoration);
                        x.Add(decoration);
                    }
                }
                t.MainDecorations = x;
            }
            if (t.MainPhotodata != null)
            {
                List<Photodatum> x = new();
                foreach (var photodatum in t.MainPhotodata)
                {
                    if (photodatum.Id == 0)
                    {
                        var added = UOW.PhotoData.Add(photodatum);
                        x.Add(added);
                    }
                    else
                    {
                        UOW.PhotoData.Update(photodatum);
                        x.Add(photodatum);
                    }
                }
                t.MainPhotodata = x;
            }
            if (t.MainStructures != null)
            {
                List<Structure> x = new();
                foreach (var s in t.MainStructures)
                {
                    if (s.Id == 0)
                    {
                        var added = UOW.Structure.Add(s);
                        x.Add(added);
                    }
                    else
                    {
                        UOW.Structure.Update(s);
                        x.Add(s);
                    }
                }
                t.MainStructures = x;
            }
            if (t.MainAnalyses != null)
            {
                List<Analysis> x = new();
                foreach (var a in t.MainAnalyses)
                {
                    if (a.Id == 0)
                    {
                        var added = UOW.Analysis.Add(a);
                        x.Add(added);
                    }
                    else
                    {
                        UOW.Analysis.Update(a);
                        x.Add(a);
                    }
                }
                t.MainAnalyses = x;
            }
            if (t.MainTextilefunctions != null)
            {
                List<Textilefunction> x = new();
                foreach (var tf in t.MainTextilefunctions)
                {
                    if (tf.Id == 0)
                    {
                        var added = UOW.TextileFunction.Add(tf);
                        x.Add(added);
                    }
                    else
                    {
                        UOW.TextileFunction.Update(tf);
                        x.Add(tf);
                    }
                }
                t.MainTextilefunctions = x;
            }
            if (t.MainYarnmanipulations != null)
            {
                List<Yarnmanipulation> x = new();
                foreach (var y in t.MainYarnmanipulations)
                {
                    if (y.Id == 0)
                    {
                        var added = UOW.YarnManipulation.Add(y);
                        x.Add(added);
                    }
                    else
                    {
                        UOW.YarnManipulation.Update(y);
                        x.Add(y);
                    }
                }
                t.MainYarnmanipulations = x;
            }
            if (t.MainBurialmains != null)
            {
                List<Burialmain> x = new();
                foreach (var bf in t.MainBurialmains)
                {
                    if (bf.Id == 0)
                    {
                        var added = UOW.BurialMain.Add(bf);
                        x.Add(added);
                    }
                    else
                    {
                        UOW.BurialMain.Update(bf);
                        x.Add(bf);
                    }
                }
                t.MainBurialmains = x;
            }
            return t;
        }
    }
}
