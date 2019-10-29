using AutoMapper;
using CustomerService.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CustomerService.Data.Services;
using System.Web.Http;
using CustomerService.Data.Services.ServiceModels;
using CustomerService.Data;
using CustomerService.Api.Utils;
using CustomerService.Api.Models;
using CustomerService.Api.Models.RequestModels;
using CustomerService.Data.Services.ServiceModels.ServiceRequestModels;
using System;

namespace CustomerService.Test
{
    [TestClass]
    public class TestCustomerService
    {
        [TestMethod]
        public void ServiceReturnsSameIdAsRequested()
        {
            // Arrange
            var config = new MapperConfiguration(cfg =>
            {
                //Create all maps here
                cfg.CreateMap<Customer, CustomerServiceModel>();
                cfg.CreateMap<Transaction, TransactionServiceModel>();
            });
            var mapper = config.CreateMapper();
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(x => x.GetCustomerBy(1)).Returns(new Data.Customer { ID = 1 });
            var service = new CustomerService.Data.Services.Impl.CustomerService(mockRepository.Object, mapper);

            // Act
            CustomerServiceModel actionResult = service.GetCustomer(new Data.Services.ServiceModels.ServiceRequestModels.CustomerServiceRequestModel() { customerID = 1});

            // Assert
            Assert.AreEqual(1, actionResult.ID);
        }
    }
}
