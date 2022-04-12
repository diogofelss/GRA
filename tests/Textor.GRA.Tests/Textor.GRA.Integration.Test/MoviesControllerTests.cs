using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Textor.GRA.Application.Services.Interfaces;
using Textor.GRA.Application.ViewModels;
using Textor.GRA.Service.Controllers;
using Xunit;

namespace Textor.GRA.Integration.Test
{
    public class MoviesControllerTests
    {
        [Fact]
        public void MoviesController_ReturnOkNominatedSinceAlways()
        {
            var movie = new MovieResponseViewModel
            {
                Year = 2021,
                Title = "Matrix 4",
                Winner = true
            };

            Moq.Mock<IMovieApplicationService> service = new();
            service.Setup(x => x.GetNominated()).Returns(new List<MovieResponseViewModel>() { movie });

            var controller = new MoviesController(service.Object);

            var response = controller.GetNominated();

            var okResult = Assert.IsType<OkObjectResult>(response);
            var list = Assert.IsType<List<MovieResponseViewModel>>(okResult.Value);

            Assert.Single(list);
        }

        [Fact]
        public void MoviesController_ReturnNotFoundNominatedSinceAlways()
        {
            Moq.Mock<IMovieApplicationService> service = new();
            service.Setup(x => x.GetNominated()).Returns(new List<MovieResponseViewModel>());

            var controller = new MoviesController(service.Object);

            var response = controller.GetNominated();

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void MoviesController_ReturnOkNominatedByYear()
        {
            var movie = new MovieResponseViewModel
            {
                Year = 2021,
                Title = "Matrix 4",
                Winner = true
            };

            Moq.Mock<IMovieApplicationService> service = new();
            service.Setup(x => x.GetNominated(2021)).Returns(new List<MovieResponseViewModel>() { movie });

            var controller = new MoviesController(service.Object);

            var response = controller.GetNominated(2021);

            var okResult = Assert.IsType<OkObjectResult>(response);
            var list = Assert.IsType<List<MovieResponseViewModel>>(okResult.Value);

            Assert.Single(list);
        }

        [Fact]
        public void MoviesController_ReturnNotFoundNominatedByYear()
        {
            Moq.Mock<IMovieApplicationService> service = new();
            service.Setup(x => x.GetNominated(2021)).Returns(new List<MovieResponseViewModel>());

            var controller = new MoviesController(service.Object);

            var response = controller.GetNominated(2021);

            Assert.IsType<NotFoundResult>(response);
        }

        /*********/

        [Fact]
        public void MoviesController_ReturnOkWinnersSinceAlways()
        {
            var movie = new MovieResponseViewModel
            {
                Year = 2021,
                Title = "Matrix 4",
                Winner = true
            };

            Moq.Mock<IMovieApplicationService> service = new();
            service.Setup(x => x.GetWinners()).Returns(new List<MovieResponseViewModel>() { movie });

            var controller = new MoviesController(service.Object);

            var response = controller.GetWinners();

            var okResult = Assert.IsType<OkObjectResult>(response);
            var list = Assert.IsType<List<MovieResponseViewModel>>(okResult.Value);

            Assert.Single(list);
        }

        [Fact]
        public void MoviesController_ReturnNotFoundWinnersSinceAlways()
        {
            Moq.Mock<IMovieApplicationService> service = new();
            service.Setup(x => x.GetWinners()).Returns(new List<MovieResponseViewModel>());

            var controller = new MoviesController(service.Object);

            var response = controller.GetWinners();

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void MoviesController_ReturnOkWinnersByYear()
        {
            var movie = new MovieResponseViewModel
            {
                Year = 2021,
                Title = "Matrix 4",
                Winner = true
            };

            Moq.Mock<IMovieApplicationService> service = new();
            service.Setup(x => x.GetWinners(2021)).Returns(new List<MovieResponseViewModel>() { movie });

            var controller = new MoviesController(service.Object);

            var response = controller.GetWinners(2021);

            var okResult = Assert.IsType<OkObjectResult>(response);
            var list = Assert.IsType<List<MovieResponseViewModel>>(okResult.Value);

            Assert.Single(list);
        }

        [Fact]
        public void MoviesController_ReturnNotFoundWinnersByYear()
        {
            Moq.Mock<IMovieApplicationService> service = new();
            service.Setup(x => x.GetWinners(2021)).Returns(new List<MovieResponseViewModel>());

            var controller = new MoviesController(service.Object);

            var response = controller.GetWinners(2021);

            Assert.IsType<NotFoundResult>(response);
        }
    }
}
