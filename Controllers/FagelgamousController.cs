//using Group1_5_FagelGamous.Data;
using Group1_5_FagelGamous.Data.Entities;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using PureTruthApi.Data.UnitOfWork;

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
            var burialmainTextiles = UOW.BurialMainTextile.Query()
                .Include(x => x.BurialMain)
                .Include(x => x.Textiles)
                .ToList();

            var DecorationTextiles = UOW.DecorationTextile.Query()
                .Include(x => x.Textiles)
                .Include(x => x.Decorations)
                .ToList();

            var together = from x in burialmainTextiles
                           join xy in DecorationTextiles on x.MainTextileid equals xy.MainTextileid
                           select x;
            return Ok(together);
        }
    }
}
