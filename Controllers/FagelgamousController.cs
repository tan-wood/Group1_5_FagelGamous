//using Group1_5_FagelGamous.Data;
using Group1_5_FagelGamous.Data.Entities;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using PureTruthApi.Data.UnitOfWork;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;
using Group1_5_FagelGamous.Infrastructure;

namespace Group1_5_FagelGamous.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class FagelgamousController : ControllerBase
    {
        private readonly IUnitOfWork UOW;
        public FagelgamousController(IUnitOfWork unitOfWork) 
        { 
            UOW= unitOfWork;
        }

        [HttpGet("getEverything")]
        public IActionResult GetEverything()
        {
            try
            {
                var everything = UOW.BurialMain.Query()
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainAnalyses)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainBurialmains)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainColors)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainDecorations)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainPhotodata)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainStructures)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainTextilefunctions)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainYarnmanipulations)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainDimensions)
               .ToArray();

                var json = CyclicalJsonHelper.DeCyclifyYoCode(everything);

                return Ok(json);

            }
            catch(Exception ex) 
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        [HttpGet("getAllBurialMain")]
        public IActionResult GetAllBurialMain()
        {
            try
            {
                var burialMain = UOW.BurialMain.GetAll().ToArray();
                return Ok(burialMain);
            }
            catch(Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        [HttpGet("getAllTextiles")]
        public IActionResult GetAllTextiles()
        {
            try
            {
                var textiles = UOW.Textile.GetAll().ToArray();
                UOW.Complete();
                return Ok(textiles);
            }
            catch(Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        [HttpGet("getAllColors")]
        public IActionResult GetAllColors()
        {
            try
            {
                var colors = UOW.Color.GetAll().ToArray();
                UOW.Complete();

                var json = CyclicalJsonHelper.DeCyclifyYoCode(colors);

                return Ok(colors);
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }


        [HttpPost("createBurialMain")]
        public IActionResult CreateBurialMain([FromBody]Burialmain b)
        {
            try
            {
                var addedBurialMain = UOW.BurialMain.Add(b);
                UOW.Complete();
                return Ok(addedBurialMain);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("createTextile")]
        public IActionResult CreateTextile([FromBody] Textile t)
        {
            try
            {
                if(t.MainColors != null)
                {
                    List<Color> x = new();
                    foreach(var color in t.MainColors)
                    {
                        var colors = UOW.Color.Add(color);
                        x.Add(colors);
                    }
                    t.MainColors = x;
                }
                if (t.MainDimensions != null)
                {
                    List<Dimension> x = new();
                    foreach (var dimension in t.MainDimensions)
                    {
                        var addedDimension = UOW.Dimension.Add(dimension);
                        x.Add(addedDimension);
                    }
                    t.MainDimensions = x;
                }
                if (t.MainDecorations != null)
                {
                    List<Decoration> x = new();
                    foreach (var decoration in t.MainDecorations)
                    {
                        var addedDecoration = UOW.Decoration.Add(decoration);
                        x.Add(addedDecoration);
                    }
                    t.MainDecorations = x;
                }
                if (t.MainDimensions != null)
                {
                    List<Dimension> x = new();
                    foreach (var dimension in t.MainDimensions)
                    {
                        var addDimension = UOW.Dimension.Add(dimension);
                        x.Add(addDimension);
                    }
                    t.MainDimensions = x;
                }
                if (t.MainPhotodata != null)
                {
                    List<Photodatum> x = new();
                    foreach (var photodatum in t.MainPhotodata)
                    {
                        var addPhotodatum = UOW.PhotoData.Add(photodatum);
                        x.Add(addPhotodatum);
                    }
                    t.MainPhotodata = x;
                }
                if (t.MainStructures != null)
                {
                    List<Structure> x = new();
                    foreach (var s in t.MainStructures)
                    {
                        var added = UOW.Structure.Add(s);
                        x.Add(added);
                    }
                    t.MainStructures = x;
                }
                if (t.MainAnalyses != null)
                {
                    List<Analysis> x = new();
                    foreach (var a in t.MainAnalyses)
                    {
                        var added = UOW.Analysis.Add(a);
                        x.Add(added);
                    }
                    t.MainAnalyses = x;
                }
                if (t.MainTextilefunctions != null)
                {
                    List<Textilefunction> x = new();
                    foreach (var tf in t.MainTextilefunctions)
                    {
                        var added = UOW.TextileFunction.Add(tf);
                        x.Add(added);
                    }
                    t.MainTextilefunctions = x;
                }
                if (t.MainYarnmanipulations != null)
                {
                    List<Yarnmanipulation> x = new();
                    foreach (var y in t.MainYarnmanipulations)
                    {
                        var added = UOW.YarnManipulation.Add(y);
                        x.Add(added);
                    }
                    t.MainYarnmanipulations = x;
                }

                var addedTextile = UOW.Textile.Add(t);
                UOW.Complete();
                return Ok(new JsonResult("Your textile has been added"));
            }
            catch(Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        [HttpDelete]
        [Route("deleteBurialMain")]
        public IActionResult DeleteBurialMain(int id)
        {
            try
            {
                var burialMain = UOW.BurialMain.GetById(id);
                if ( burialMain == null)
                {
                    return Ok(new JsonResult("This is null"));
                }
                UOW.BurialMain.Remove(burialMain);
                UOW.Complete();
                return new JsonResult("It worked and is deleted");
            }
            catch(Exception ex )
            {
                return BadRequest(new JsonResult($"Bad request: {ex.Message}"));
            }
        }

        [HttpPut]
        [Route("updateBurialMain")]
        public IActionResult UpdateBurialMain([FromBody] Burialmain b)
        {
            try
            {
                    UOW.BurialMain.Update(b);
                
            }catch(Exception ex)
            {
                return BadRequest(new JsonResult($"Bad request: {ex.Message}"));
            }

            UOW.Complete();

            return Ok(new JsonResult("Your burial has been updated"));
        }


        //TODO: Normalize the flippin database so that we have a colors table
        //TODO: Potentials: dimensions, decoration, dimensions, photodatum, structure, analysis, textilefunction, yarnmanipulation



    }
}
