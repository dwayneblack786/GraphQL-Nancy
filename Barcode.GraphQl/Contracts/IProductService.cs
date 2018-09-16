using System.Threading.Tasks;
using Barcode.Common.Model.Product;

namespace Barcode.GraphQL.Contracts
{
    public interface IProductService
    {
        Task<ProductCollection> GetByProductIdAsync(string id);
        Task<ProductCollection> GetByBarcodeAsync(string barcode);

        Task<string> AddProductAsync(ProductRequest product);
        Task<bool> UpdateProductAsync(ProductRequest product);

    }
}