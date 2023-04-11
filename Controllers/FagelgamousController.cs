//using Group1_5_FagelGamous.Data;
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

        //[HttpGet("getEverything")]
        //public IActionResult GetEverything()
        //{
        //    var everything = UOW.BurialMain.Query()
        //        .Include(x=> x.)
        //}
    }
}
