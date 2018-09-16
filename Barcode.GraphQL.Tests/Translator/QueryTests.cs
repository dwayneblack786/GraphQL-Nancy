using Barcode.GraphQL.Tests.Configurations.Providers;
using Barcode.GraphQL.Translators;
using FluentAssertions;
using Xunit;

namespace Barcode.GraphQL.Tests.Translator
{
    public class QueryTests : IClassFixture<TestServiceProviderFixture>
    {
        private readonly TestServiceProviderFixture _serviceProviderFixture;

        public QueryTests(TestServiceProviderFixture serviceProviderFixture)
        {
            _serviceProviderFixture = serviceProviderFixture;
        }

        [Fact]
        public void ReturnFormattedText()
        {
            // Given

            var query = new Query(_serviceProviderFixture.ServiceProvider);

            // When
            query.Should().NotBeNull();

            // Then
        }
    }
}
