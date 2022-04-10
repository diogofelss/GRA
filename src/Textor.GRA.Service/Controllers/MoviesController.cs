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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieResponseViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("first")]
        public IActionResult First()
        {
            return Ok(MovieApplicationService.Get());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<MovieResponseViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("")]
        public IActionResult GetAll()
        {
            return Ok(MovieApplicationService.GetAll());
        }
    }
}