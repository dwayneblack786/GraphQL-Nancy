using System.Linq;
using Barcode.GraphQL.Translators;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Barcode.GraphQL.Tests.Translator
{
    public class RequestTests
    {

        [Fact]
        public void Request_ReturnFormattedText()
        {
            // Given
            string[] expectedProperties = { "OperationName", "NamedQuery", "Query", "Variables" };
            object[] expectedType = { typeof(string), typeof(JObject) };

            // When
            var queryShould = new Request()
            {
                OperationName = "OperationName",
                NamedQuery = "NamedQuery",
                Query = "Query",
                Variables = JObject.Parse("{\"somestring\":\"0\"}")
            };

            // Then
            queryShould.Should().BeOfType(typeof(Request));
            var value = queryShould.Variables.GetValue("somestring");
            value.ToString().Should().BeEquivalentTo("0");
            queryShould.NamedQuery.Should().Be("NamedQuery");
            queryShould.Query.Should().Be("Query");
            queryShould.OperationName.Should().Be("OperationName");
            var propertyInfos = typeof(Request).GetProperties();
            propertyInfos.Length.Should().Be(4);
            // writes all the property names
            foreach (var propertyInfo in propertyInfos)
            {
                expectedProperties.Contains(propertyInfo.Name).Should().BeTrue();
            }

            foreach (var propertyInfo in propertyInfos)
            {
                expectedType.Contains(propertyInfo.PropertyType).Should().BeTrue();
            }
        }
    }
}
