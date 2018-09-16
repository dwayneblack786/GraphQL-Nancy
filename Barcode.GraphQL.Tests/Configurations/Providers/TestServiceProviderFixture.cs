using System;

namespace Barcode.GraphQL.Tests.Configurations.Providers
{
   
        public class TestServiceProviderFixture : IDisposable
        {
            public TestServiceProvider ServiceProvider { get; }
            public TestServiceProviderFixture()
            {
                ServiceProvider = new TestServiceProvider();
;            }

            public void Dispose()
            {
                ServiceProvider.Dispose();
            }
        }
}
