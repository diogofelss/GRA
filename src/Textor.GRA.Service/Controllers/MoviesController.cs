using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Textor.GRA.Application.Services.Interfaces;
using Textor.GRA.Application.ViewModels;

namespace Textor.GRA.Service.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieApplicationService MovieApplicationService;

        public MoviesController(IMovieApplicationService movieApplicationService)
        {
            MovieApplicationService = movieApplicationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<MovieResponseViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{year}/nominated")]
        public IActionResult GetNominated(int year)
        {
            return Ok(MovieApplicationService.GetNominated(year));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<MovieResponseViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{year}/winners")]
        public IActionResult GetWinners(int year)
        {
            return Ok(MovieApplicationService.GetWinners(year));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<MovieResponseViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("all/nominated")]
        public IActionResult GetNominated()
        {
            return Ok(MovieApplicationService.GetNominated());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<MovieResponseViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("all/winners")]
        public IActionResult GetWinners()
        {
            return Ok(MovieApplicationService.GetWinners());
        }
    }
}