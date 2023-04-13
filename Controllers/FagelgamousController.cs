//using Group1_5_FagelGamous.Data;
using Group1_5_FagelGamous.Data.Entities;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Group1_5_FagelGamous.Data.UnitOfWork;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;
using Group1_5_FagelGamous.Infrastructure;
using System.Diagnostics;
using Group1_5_FagelGamous.Data.DTO.Authentication;

namespace Group1_5_FagelGamous.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class FagelgamousController : ControllerBase
    {
        private readonly IUnitOfWork UOW;
        private readonly ControllerHelper Helper;
        public FagelgamousController(IUnitOfWork unitOfWork) 
        { 
            UOW= unitOfWork;
            Helper = new ControllerHelper(UOW);
        }

        [HttpGet("getEverything")]
        public IActionResult GetEverything()
        {
            try
            {
                var everything = UOW.BurialMain.Query()
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainAnalyses)
               .Include(x => x.MainTextiles).ThenInclude(x =>x.MainBurialmains)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainColors)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainDecorations)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainPhotodata)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainStructures)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainTextilefunctions)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainYarnmanipulations)
               .Include(x => x.MainTextiles).ThenInclude(x => x.MainDimensions)
               .ToArray();

                var json = Helper.DeCyclifyYoCode(everything);

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

        [HttpGet("getSingleBurialMain/{id}")]
        public IActionResult GetSingleBurialMain(int id)
        {
            try
            {
                var burialMain = UOW.BurialMain.Query()
                    .Where(x => x.Id == id)
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

                var json = Helper.DeCyclifyYoCode(burialMain);
                return Ok(json);
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        [HttpGet("getAllTextiles")]
        public IActionResult GetAllTextiles()
        {
            try
            {
                var textiles = UOW.Textile.Query()
                    .Include(x=>x.MainTextilefunctions)
                    .Include(x=>x.MainStructures)
                    .Include(x=>x.MainYarnmanipulations)
                    .Include(x=>x.MainAnalyses)
                    .Include(x=>x.MainBurialmains)
                    .Include(x=>x.MainColors)
                    .Include(x=>x.MainDecorations)
                    .Include(x=>x.MainPhotodata)
                    .Include(x=>x.MainDimensions)
                    .ToArray();
                var json = Helper.DeCyclifyYoCode(textiles);
                
                return Ok(json);
            }
            catch(Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        [HttpGet("getSingleTextile/{id}")]
        public IActionResult GetSingleTextiles(int id)
        {
            try
            {
                var textiles = UOW.Textile.Query()
                    .Where(x=> x.Id == id)
                    .Include(x => x.MainTextilefunctions)
                    .Include(x => x.MainStructures)
                    .Include(x => x.MainYarnmanipulations)
                    .Include(x => x.MainAnalyses)
                    .Include(x => x.MainBurialmains)
                    .Include(x => x.MainColors)
                    .Include(x => x.MainDecorations)
                    .Include(x => x.MainPhotodata)
                    .Include(x => x.MainDimensions)
                    .ToArray();
                var json = Helper.DeCyclifyYoCode(textiles);

                return Ok(json);
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }


        [HttpPost("createBurialMain")]
        public IActionResult CreateBurialMain([FromBody]BurialMainDTO b)
        {
            try
            {
                //if(b.MainTextiles != null)
                //{
                //    IEnumerable<Textile> text= UOW.Textile.AddRange(b.MainTextiles);
                //    b.MainTextiles = (ICollection<Textile>)text;
                //}
                Burialmain newBurialMain = new(b.Id, b.Squarenorthsouth, b.Headdirection, b.Sex, b.Northsouth, b.Depth, b.Eastwest, b.Adultsubadult, b.Facebundles, b.Southtohead, b.Preservation, b.Fieldbookpage, b.Squareeastwest, b.Goods,
                    b.Text, b.Wrapping, b.Haircolor, b.Westtohead, b.Samplescollected, b.Area, b.Burialid, b.Length, b.Burialnumber, b.Dataexpertinitials, b.Westtofeet, b.Ageatdeath, b.Southtofeet,
                    b.Excavationrecorder, b.Photos, b.Hair, b.Burialmaterials, b.Dateofexcavation, b.Fieldbookexcavationyear, b.Clusternumber, b.Shaftnumber);

                var addedBurialMain = UOW.BurialMain.Add(newBurialMain);
                UOW.Complete();
                var json = Helper.DeCyclifyYoCode(addedBurialMain);
                return Ok(json);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("createTextile")]
        public IActionResult CreateTextile([FromBody] TextileDTO t)
        {
            try
            {
                ////This goes through the process of determining if we need to add the sub portions of a textile
                //t = Helper.TextileBuilder(t);
                Textile newTextile = new(t.Id, t.Locale, t.Textileid, t.Description, t.Burialnumber, t.Estimatedperiod, t.Sampledate, t.Photographeddate, t.Direction);
                var addedTextile = UOW.Textile.Add(newTextile);
                UOW.Complete();
                return Ok(addedTextile);
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

        [HttpDelete]
        [Route("deleteTextile")]
        public IActionResult DeleteTextile(int id)
        {
            try
            {
                var textile = UOW.Textile.GetById(id);
                if (textile == null)
                {
                    return BadRequest(new JsonResult("This is null"));
                }
                UOW.Textile.Remove(textile);
                UOW.Complete();
                return new JsonResult("It worked and is deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult($"Bad request: {ex.Message}"));
            }
        }

        [HttpPut]
        [Route("updateBurialMain")]
        public IActionResult UpdateBurialMain([FromBody] BurialMainDTO b)
        {
            try
            {
                //if there are textiles in this burial main
                //if (b.MainTextiles != null)
                //{
                //    //build a new list that will hold the newly created/ updated textiles
                //    List<Textile> x = new();
                //    foreach (var textile in b.MainTextiles)
                //    {
                //        //if the textile id is not yet created (the id is set to 0 initially)
                //        if (textile.Id == 0)
                //        {
                //            //Since this is a brand new textile, we need to go through the same process as when we created a textile and add its sub components
                //            Textile tNew = Helper.TextileBuilder(textile);
                //            //then go and add this textile to the textile table
                //            var added = UOW.Textile.Add(tNew);
                //            //Then add it to the overall list
                //            x.Add(added);
                //        }
                //        //if the textile does exist already(meaning there is a textile id)
                //        else
                //        {
                //            //then update that textile with the current one
                //            UOW.Textile.Update(textile);
                //            //Add this textile back to the maintextiles
                //            x.Add(textile);
                //        }
                //    }
                //    b.MainTextiles = x;
                //}

                Burialmain BurialMain = new(b.Id, b.Squarenorthsouth, b.Headdirection, b.Sex, b.Northsouth, b.Depth, b.Eastwest, b.Adultsubadult, b.Facebundles, b.Southtohead, b.Preservation, b.Fieldbookpage, b.Squareeastwest, b.Goods,
                    b.Text, b.Wrapping, b.Haircolor, b.Westtohead, b.Samplescollected, b.Area, b.Burialid, b.Length, b.Burialnumber, b.Dataexpertinitials, b.Westtofeet, b.Ageatdeath, b.Southtofeet,
                    b.Excavationrecorder, b.Photos, b.Hair, b.Burialmaterials, b.Dateofexcavation, b.Fieldbookexcavationyear, b.Clusternumber, b.Shaftnumber);

                var updatedBurialMain = UOW.BurialMain.Update(BurialMain);
                UOW.Complete();

                return Ok("Your burial has been updated");
            }
            catch(Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }

        }

        [HttpPut("updateTextile")]
        public IActionResult UpdateTextile([FromBody] TextileDTO t)
        {
            try
            {
                ////resetting the object t with all the updated/created subportions
                //t = Helper.TextileBuilder(t);
                Textile toUpdateTextile = new(t.Id, t.Locale, t.Textileid, t.Description, t.Burialnumber, t.Estimatedperiod, t.Sampledate, t.Photographeddate, t.Direction);
                UOW.Textile.Update(toUpdateTextile);
                UOW.Complete();
                return Ok(new JsonResult("Your textile has been updated"));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

    }
}
