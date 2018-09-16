using System;
using Barcode.Common.Model.Configuration;
using Barcode.GraphQL.Tests.Configurations.Base;
using Microsoft.Extensions.Options;
using ServiceCollectionContainerBuilderExtensions = Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions;

namespace Barcode.GraphQL.Tests.Configurations.Product
{
    public class TestProductServiceFixture : IDisposable
    {
        public TestProductService TestProductService { get; }
        public string Barcode
        {
            get
            {
                var random = new Random();
                return random.Next(int.MinValue, int.MaxValue).ToString();
            }
        }
        public TestProductServiceFixture()
        {
            var services = new ServiceProvider().ServiceCollection;
            var appServices = ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services);
            var config = appServices.GetService(typeof(IOptions<Application>));
            TestProductService = new TestProductService(config as IOptions<Application>);
        }

        public void Dispose()
        {
            TestProductService.Dispose();
        }
    }
}