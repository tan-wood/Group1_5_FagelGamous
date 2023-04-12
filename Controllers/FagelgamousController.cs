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
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                    ReferenceHandler = ReferenceHandler.IgnoreCycles // Disable reference handling
                };

                var json = JsonSerializer.Serialize(everything, options);

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

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                    ReferenceHandler = ReferenceHandler.IgnoreCycles // Disable reference handling
                };

                var json = JsonSerializer.Serialize(colors, options);

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
                var addedTextile = UOW.Textile.Add(t);
                UOW.Complete();
                return Ok(new JsonResult("Your textile has been added sir"));
            }
            catch(Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        [HttpPost("createColor")]
        public IActionResult CreateColor([FromBody] Color c)
        {
            try
            {
                var addedColor = UOW.Color.Add(c);
                UOW.Complete();
                return Ok(addedColor);
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }
        //dimensions
        //decoration
        //dimensions
        //photodatum
        //structure
        //analysis
        //textilefunction
        //yarnmanipulation



        [HttpDelete]
        [Route("deleteBurialMain")]
        public JsonResult DeleteBurialMain(long id)
        {
            try
            {
                var burialMain = UOW.BurialMain.GetById(id);
                if ( burialMain == null)
                {
                    return new JsonResult("This is null");
                }
                UOW.BurialMain.Remove(burialMain);
                UOW.Complete();
                return new JsonResult("It worked and is deleted");
            }
            catch(Exception ex )
            {
                return new JsonResult($"Bad request buddy: {ex.Message}");
            }
        }

        // routes to finish
            //update burialmain
        
        //make sure to change everything to have exceptions on the catch... and the json result

        // Crud
        // burialmain
        // textile
        // Bonus
        //subcomponents of textile is a plus but not required

        //update is change entity1 and change entity2 nothin in link
        // create is add entity1 and add eneity2 then add both pk in link
        // delete is delete from e1 and delete from e2 then delete the pks of each from link

        //TODO: Make helper function that avoids returning cyclical stuff
    }
}
