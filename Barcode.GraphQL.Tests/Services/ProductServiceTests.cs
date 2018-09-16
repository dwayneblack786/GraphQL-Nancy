using System;
using System.Linq;
using System.Threading.Tasks;
using Barcode.Common.Model.Product;
using Barcode.GraphQL.Tests.Configurations.Product;
using FluentAssertions;
using Flurl.Http;
using MongoDB.Bson;
using Newtonsoft.Json;
using Xunit;

namespace Barcode.GraphQL.Tests.Services
{
    public class ProductServiceTests : IClassFixture<TestProductServiceFixture>
    {
        private readonly TestProductServiceFixture _fixture;

        public ProductServiceTests(TestProductServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task AddProductAsync_should_add_a_new_product_Async()
        {
            var barcode = _fixture.Barcode;
            var prod = new ProductDetail
            {
                Barcode = barcode,
                Category = Category.AutoMobile.DisplayName,
                ProductName = "A new product",
                Description = "Test test"
            };

            var request = new ProductRequest
            {
                ProductDetail = prod,
                ProductCollection = new ProductCollection { Category = Category.AutoMobile.DisplayName, Barcode = barcode }
            };

            var addedResults = await _fixture.TestProductService.AddProductAsync(request);
            var id = ObjectId.Parse(addedResults);
            id.Should().BeOfType(typeof(ObjectId));
        }


        [Fact]
        public async Task GetByProductIdAsync_should_get_a_new_product_added_Async()
        {
            var barcode = _fixture.Barcode;
            var prod = new ProductDetail
            {
                Barcode = barcode,
                Category = Category.AutoMobile.DisplayName,
                ProductName = "A new product",
                Description = "Test test"
            };

            var request = new ProductRequest
            {
                ProductDetail = prod,
                ProductCollection = new ProductCollection { Category = Category.AutoMobile.DisplayName, Barcode = barcode }

            };

            var addedResults = await _fixture.TestProductService.AddProductAsync(request);
            var id = ObjectId.Parse(addedResults);
            id.Should().BeOfType(typeof(ObjectId));


            var getResult = await _fixture.TestProductService.GetByProductIdAsync(addedResults);
            getResult.Should().NotBeNull();
        }


        [Fact]
        public async Task GetByBarcodeAsync_should_Not_be_null_Async()
        {
            var barcode = _fixture.Barcode;
            var prod = new ProductDetail
            {
                Barcode = barcode,
                Category = Category.AutoMobile.DisplayName,
                ProductName = "A new product",
                Description = "Test test"
            };

            var request = new ProductRequest
            {
                ProductDetail = prod,
                ProductCollection = new ProductCollection { Category = Category.AutoMobile.DisplayName, Barcode = barcode }

            };

            var addedResults = await _fixture.TestProductService.AddProductAsync(request);
            var id = ObjectId.Parse(addedResults);
            id.Should().BeOfType(typeof(ObjectId));

            var getResult = await _fixture.TestProductService.GetByBarcodeAsync(request.ProductCollection.Barcode);
            getResult.Should().NotBeNull();
        }

        [Fact]
        public async Task AddProductAsync_should_throw_exception_if_passed_null_Async()
        {
            try
            {
                await _fixture.TestProductService.AddProductAsync(null);
            }
            catch (Exception e)
            {
                e.Should().BeOfType<FlurlHttpException>();
            }
        }

        [Fact]
        public async Task UpdateProductAsync_should_throw_exception_if_passed_null_Async()
        {

            try
            {
                await _fixture.TestProductService.UpdateProductAsync(null);
            }
            catch (Exception e)
            {
                e.Should().BeOfType<FlurlHttpException>();
            }
        }

        [Fact]
        public async Task UpdateProductAsync_should_Not_be_true_Async()
        {
            var barcode = _fixture.Barcode;
            var prod = new ProductDetail
            {
                Barcode = barcode,
                Category = Category.AutoMobile.DisplayName,
                ProductName = "A new product",
                Description = "Test test"
            };

            var request = new ProductRequest
            {
                ProductDetail = prod,
                ProductCollection = new ProductCollection { Category = Category.AutoMobile.DisplayName, Barcode = barcode }

            };

            var addedResults = await _fixture.TestProductService.AddProductAsync(request);
            var id = ObjectId.Parse(addedResults);
            id.Should().BeOfType(typeof(ObjectId));

            var getResult = await _fixture.TestProductService.GetByProductIdAsync(addedResults);
            getResult.Should().NotBeNull();

            var lastBlockInTheChain = getResult.ProductChain.LastOrDefault();

            var dataToUpdate = JsonConvert.DeserializeObject<ProductDetail>(lastBlockInTheChain?.Data);

            dataToUpdate.Category = Category.GroceryStore.DisplayName;
            getResult.Category = dataToUpdate.Category;
            var requestUpdate = new ProductRequest
            {
                ProductDetail = dataToUpdate,
                ProductCollection = getResult
            };

            var updateResult = await _fixture.TestProductService.UpdateProductAsync(requestUpdate);

            updateResult.Should().BeTrue();

            var getUpdatedResult = await _fixture.TestProductService.GetByProductIdAsync(addedResults);

            getUpdatedResult.Category.Should().Be(getResult.Category);

            var dataToUpdated = JsonConvert.DeserializeObject<ProductDetail>(getUpdatedResult.ProductChain.LastOrDefault()?.Data);

            dataToUpdated.Category.Should().Be(dataToUpdate.Category);
        }
    }
}
