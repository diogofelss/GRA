using Microsoft.AspNetCore.Mvc;
using Textor.GRA.Application.Services.Interfaces;
using Textor.GRA.Application.ViewModels;
using Textor.GRA.Service.Controllers;
using Xunit;

namespace Textor.GRA.Integration.Test
{
    public class ProducersControllerTests
    {
        [Fact]
        public void ProducersController_ReturnOkWinnersInterval()
        {
            var item = new ProducerWinnerTimeResponseViewModel();
            item.Max.Add(new ProducerWinnerTimeItemResponseViewModel
            {
                FollowingWin = 1980,
                PreviousWin = 1991,
                Interval = 11,
                Producer = "Producer 1"
            });
            item.Min.Add(new ProducerWinnerTimeItemResponseViewModel
            {
                FollowingWin = 1990,
                PreviousWin = 1991,
                Interval = 1,
                Producer = "Producer 2"
            });

            Moq.Mock<IProducerApplicationService> service = new();
            service.Setup(x => x.GetInterval()).Returns(item);

            var controller = new ProducersController(service.Object);

            var response = controller.GetInterval();

            var okResult = Assert.IsType<OkObjectResult>(response);
            var list = Assert.IsType<ProducerWinnerTimeResponseViewModel>(okResult.Value);

            Assert.Single(list.Min);
            Assert.Single(list.Max);
        }

        [Fact]
        public void ProducersController_ReturnNotFoundWinnersOnlyMinInterval()
        {
            var item = new ProducerWinnerTimeResponseViewModel();
            item.Min.Add(new ProducerWinnerTimeItemResponseViewModel
            {
                FollowingWin = 1990,
                PreviousWin = 1991,
                Interval = 1,
                Producer = "Producer 2"
            });

            Moq.Mock<IProducerApplicationService> service = new();
            service.Setup(x => x.GetInterval()).Returns(item);

            var controller = new ProducersController(service.Object);

            var response = controller.GetInterval();

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void ProducersController_ReturnNotFoundWinnersOnlyMaxInterval()
        {
            var item = new ProducerWinnerTimeResponseViewModel();
            item.Max.Add(new ProducerWinnerTimeItemResponseViewModel
            {
                FollowingWin = 1990,
                PreviousWin = 1991,
                Interval = 1,
                Producer = "Producer 2"
            });

            Moq.Mock<IProducerApplicationService> service = new();
            service.Setup(x => x.GetInterval()).Returns(item);

            var controller = new ProducersController(service.Object);

            var response = controller.GetInterval();

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void ProducersController_ReturnNotFoundWinnersInterval()
        {
            var item = new ProducerWinnerTimeResponseViewModel();
            Moq.Mock<IProducerApplicationService> service = new();
            service.Setup(x => x.GetInterval()).Returns(item);

            var controller = new ProducersController(service.Object);

            var response = controller.GetInterval();

            Assert.IsType<NotFoundResult>(response);
        }
    }
}