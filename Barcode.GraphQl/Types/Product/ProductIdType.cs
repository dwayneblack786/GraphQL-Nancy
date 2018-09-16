using Barcode.Common.Model.Product;
using Barcode.GraphQL.Contracts;
using GraphQL.Types;

namespace Barcode.GraphQL.Types.Product
{
    public class ProductIdType : ObjectGraphType<ProductId>, IGraphQlType
    {
        public ProductIdType()
        {
            Field(x => x.Id).Description("Id for the product saved");
        }
    }
}