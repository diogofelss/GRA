using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Textor.GRA.Application.Services.Interfaces;
using Textor.GRA.Application.ViewModels;

namespace Textor.GRA.Service.Controllers
{
    [ApiController]
    [Route("producers")]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerApplicationService ProducerApplicationService;

        public ProducersController(IProducerApplicationService producerApplicationService)
        {
            ProducerApplicationService = producerApplicationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProducerWinnerTimeResponseViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("winners/interval")]
        public IActionResult GetInterval()
        {
            var result = ProducerApplicationService.GetInterval();

            if (result.Max.Any() && result.Min.Any())
                return Ok(result);

            return NotFound();
        }
    }
}