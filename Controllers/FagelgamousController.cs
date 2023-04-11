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
            var everything = UOW.Textile.Query()
                .Include(x => x.MainAnalyses)
                .Include(x => x.MainBurialmains)
                .Include(x => x.MainColors)
                .Include(x => x.MainDecorations)
                .Include(x => x.MainPhotodata)
                .Include(x => x.MainStructures)
                .Include(x => x.MainTextilefunctions)
                .Include(x => x.MainYarnmanipulations)
                .Include(x => x.MainDimensions) 
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

        [HttpGet("getAllBurialMain")]
        public IActionResult GetAllBurialMain()
        {
            try
            {
                var burialMain = UOW.BurialMain.GetAll().ToArray();
                return Ok(burialMain);
            }
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("createBurialMain")]
        public IActionResult CreateBurialMain([FromBody]Burialmain b)
        {
            try
            {
                UOW.BurialMain.Add(b);
                UOW.Complete();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //[HttpPost("deleteBurialMain")]
        //public IActionResult DeleteBurialMain(int id)
        //{
        //    if(UOW.BurialMain.GetById(id) == null)
        //    {
        //        return NotFound();
        //    }
        //    try
        //    {

        //    }
        //}

        // Crud
        // burialmain
        // textile
        // Bonus
        //subcomponents of textile is a plus but not required

        //update is change entity1 and change entity2 nothin in link
        // create is add entity1 and add eneity2 then add both pk in link
        // delete is delete from e1 and delete from e2 then delete the pks of each from link
    }
}
