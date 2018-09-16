using Barcode.GraphQL.Contracts;
using Barcode.GraphQL.Resolvers.Base;
using Barcode.GraphQL.Translators;
using Barcode.GraphQL.Types.Product;
using Barcode.GraphQL.Types.Response;
using GraphQL.Types;

namespace Barcode.GraphQL.Resolvers
{
    public class ProductQueryResolver : Resolver, IProductQueryResolver
    {
        private readonly IProductService _productService;

        public ProductQueryResolver(IProductService productService)
        {
            _productService = productService;
        }

        public void Resolve(Query productQuery)
        {
            productQuery.FieldAsync<ResponseGraphType<ProductType>>(
               "ByProductId",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "Id", Description = "Id of the product" }
               ),
               resolve: async context =>
               {
                   var productId = context.GetArgument<string>("id");
                   var product = await _productService.GetByProductIdAsync(productId);
                   return  Response(product);
               }
           );

            productQuery.Field<ResponseGraphType<ProductType>>(
                "ByBarcode",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "Barcode", Description = "Barcode of the product being retrieved" }
                ),
                resolve: context =>
                {
                    var barcode = context.GetArgument<string>("barcode");
                    var product =   _productService.GetByBarcodeAsync(barcode);
                    return product == null ? NotFoundError(barcode) : Response(product);
                }
            );
        }
    }
}
