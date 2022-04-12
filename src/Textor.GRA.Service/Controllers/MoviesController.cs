using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
            var result = MovieApplicationService.GetNominated(year);

            if (result.Any())
                return Ok(result);

            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<MovieResponseViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{year}/winners")]
        public IActionResult GetWinners(int year)
        {
            var result = MovieApplicationService.GetWinners(year);

            if (result.Any())
                return Ok(result);

            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<MovieResponseViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("all/nominated")]
        public IActionResult GetNominated()
        {
            var result = MovieApplicationService.GetNominated();

            if (result.Any())
                return Ok(result);

            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<MovieResponseViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("all/winners")]
        public IActionResult GetWinners()
        {
            var result = MovieApplicationService.GetWinners();

            if (result.Any())
                return Ok(result);

            return NotFound();
        }
    }
}