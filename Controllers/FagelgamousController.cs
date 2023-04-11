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
    }
}
