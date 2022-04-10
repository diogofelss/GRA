using Microsoft.AspNetCore.Mvc;
using Textor.GRA.Application.Services.Interfaces;

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
    }
}