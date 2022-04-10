using Microsoft.AspNetCore.Mvc;

namespace Textor.GRA.Service.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("hello")]
        public string Hello()
        {
            return "Hello world";
        }
    }
}