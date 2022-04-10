using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Textor.GRA.Application.DTOs;
using Textor.GRA.Application.Services.Interfaces;

namespace Textor.GRA.Service.Controllers
{
    [ApiController]
    [Route("teste")]
    public class TesteController : ControllerBase
    {
        private readonly IGraApplicationService graApplicationService;

        public TesteController(IGraApplicationService GraApplicationService)
        {
            graApplicationService = GraApplicationService;
        }

        [HttpGet]
        [Route("get")]
        public string Get()
        {
            return "Hello bad word"!;
        }

        [HttpGet]
        [Route("all")]
        public IList<MovieResponseDTO> GetAll()
        {
            return graApplicationService.GetAll();
        }
    }
}