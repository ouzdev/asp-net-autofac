using AspNetAutofac.API.Controllers;
using AspNetAutofac.API.Models;
using AspNetAutofac.API.Test.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AspNetAutofac.API.Test.Systems.Controllers
{
    public class TestProductsController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnStatusCode200()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetAllProductsAsync()).ReturnsAsync(ProductFixture.GetTestProducts());
            var sut = new ProductsController(mockProductService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetAllProducts();

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task Get_By_Id_OnSuccess_ReturnStatusCode200()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetProductById(1)).ReturnsAsync(ProductFixture.GetTestProduct());
            var sut = new ProductsController(mockProductService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetAllProductById(1);

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task Get_By_Id_NotFound_ReturnStatusCode404()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetProductById(1)).ReturnsAsync(ProductFixture.GetTestProduct());
            var sut = new ProductsController(mockProductService.Object);

            // Act
            var result = (NotFoundObjectResult)await sut.GetAllProductById(2);

            // Assert
            //Check Status Code
            result.StatusCode.Should().Be(404);

        }
        [Fact]
        public void Get_By_Id_OnSuccess_InvokesProductsServiceExactlyOnce()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetProductById(1)).ReturnsAsync(ProductFixture.GetTestProduct());
            var sut = new ProductsController(mockProductService.Object);
            // Act
            var result = sut.GetAllProductById(1);
            
            // Assert
            mockProductService.Verify(x => x.GetProductById(1), Times.Once);
        }
        [Fact]
        public void Get_OnSuccess_InvokesProductsServiceExactlyOnce()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetAllProductsAsync()).ReturnsAsync(ProductFixture.GetTestProducts());
            var sut = new ProductsController(mockProductService.Object);
            // Act
            var result = sut.GetAllProducts();

            // Assert
            mockProductService.Verify(x => x.GetAllProductsAsync(), Times.Once);
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnListOfProduct()
        {
            //Arange

            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetAllProductsAsync()).ReturnsAsync(ProductFixture.GetTestProducts());
            var sut = new ProductsController(mockProductService.Object);

            //Act

            var result = await sut.GetAllProducts();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<Product>>();
        }
    }
}