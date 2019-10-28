using System.Web.Http;
using WebActivatorEx;
using CustomerService.Api;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CustomerService.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "CustomerService.Api");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    })
                .EnableSwaggerUi(c => { });
        }

        private static string GetXmlCommentsPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory + @"bin\SwaggerDemoApi.xml";
        }
    }
}
