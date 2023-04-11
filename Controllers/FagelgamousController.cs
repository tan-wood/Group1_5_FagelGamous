//using Group1_5_FagelGamous.Data;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace Group1_5_FagelGamous.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FagelgamousController : ControllerBase
    {
    }
}
