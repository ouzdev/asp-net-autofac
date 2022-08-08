

using asp_net_autofac.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace asp_net_autofact.Test;

public class WeatherForecastTestController
{
    // GET
    [Fact]
    public void Get_OnSuccess_ReturnListOfProduct()
    {
        //Arange

        var mockProductService = new Mock<IProductService>();
        mockProductService.
            Setup(x => x.GetAllProducts()).
            Returns(new List<Product>());
        var sut = new WeatherForecastController(null, mockProductService.Object);

        //Act
        
        var result = sut.GetProduct();

        //Assert
        result.Should().BeOfType<OkObjectResult>();
        Assert.NotNull(result);
    }
}
