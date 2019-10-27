using AutoMapper;
using CustomerService.Api.Models;
using CustomerService.Data.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService.Api.Utils
{
    public static class MapperConfig
    {
        public static MapperConfiguration getConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //Create all maps here
                cfg.CreateMap<Customer, CustomerServiceModel>();
                cfg.CreateMap<Transaction, TransactionServiceModel>();
                cfg.CreateMap<CustomerServiceModel, CustomerApiModel>();
                cfg.CreateMap<TransactionServiceModel, TransactionApiModel>()
                 .ForMember("TransactionDateTime", opt => opt.MapFrom(c => c.TransactionDateTime.ToString("dd/MM/yy hh:mm")))
                 .ForMember("Amount", opt => opt.MapFrom(c => String.Format("{0:0.00}", c.Amount)));

            });
            return config;
        }
    }
}