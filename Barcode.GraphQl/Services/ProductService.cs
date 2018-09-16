using System.Net.Http;
using System.Threading.Tasks;
using Barcode.Common.Model.Configuration;
using Barcode.Common.Model.Product;
using Barcode.GraphQL.Contracts;
using Microsoft.Extensions.Options;
using ProductCollection = Barcode.Common.Model.Product.ProductCollection;
using Flurl;
using Flurl.Http;
using static System.String;

namespace Barcode.GraphQL.Services
{
    public class ProductService : IProductService
    {
        private readonly IOptions<Application> _appConfiguration;

        public ProductService(IOptions<Application> appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public async Task<ProductCollection> GetByProductIdAsync(string id)
        {
            var results = await _appConfiguration.Value.ProductCollectionSettings
                    .Host
                    .WithHeader("Content-Type", "application/json")
                    .AppendPathSegment(Format(_appConfiguration.Value.ProductCollectionSettings.Path.ByProductId, id))
                    .GetJsonAsync<ProductCollection>();


            return results;
        }

        public async Task<ProductCollection> GetByBarcodeAsync(string barcode)
        {
            return await _appConfiguration.Value.ProductCollectionSettings
                   .Host
                   .AppendPathSegment(Format(_appConfiguration.Value.ProductCollectionSettings.Path.ByBarcode, barcode))
                   .GetJsonAsync<ProductCollection>();
        }

        public async Task<string> AddProductAsync(ProductRequest product)
        {
            try
            {
                return await _appConfiguration.Value.ProductCollectionSettings.Host
                              .WithHeader("Content-Type", "application/json")
                              .PostAsync(new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(product))).ReceiveJson<string>();

            }
            catch (FlurlHttpException ex)
            {
                // For error responses that take a known shape
                throw ex;
            }
        }

        public async Task<bool> UpdateProductAsync(ProductRequest product)
        {
            try
            {
                return await _appConfiguration.Value.ProductCollectionSettings.Host
                        .WithHeader("Content-Type", "application/json")
                        .PutAsync(new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(product))).ReceiveJson<bool>();
            }
            catch (FlurlHttpException ex)
            {
                // For error responses that take a known shape
                throw ex;
            }
        }
    }
}
