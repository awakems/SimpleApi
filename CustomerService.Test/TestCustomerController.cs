using System;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using CustomerService.Api.Controllers;
using CustomerService.Data.Repositories;
using CustomerService.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CustomerService.Test
{
    [TestClass]
    public class TestCustomerController
    {
        [TestMethod]
        public void PostWithIdReturnsBedRequest()
        {
            // Arrange
            var mockService = new Mock<ICustomerService>();
            var mockMapper = new Mock<IMapper>();
            var controller = new CustomerController(mockService.Object, mockMapper.Object);

            // Act
            IHttpActionResult actionResult = controller.Post(new Api.Models.RequestModels.CustomerRequestModel { customerID = 999});

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }
    }
}
