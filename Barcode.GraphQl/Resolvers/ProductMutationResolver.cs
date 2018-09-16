using Barcode.Common.Model.Product;
using Barcode.GraphQL.Contracts;
using Barcode.GraphQL.Resolvers.Base;
using Barcode.GraphQL.Translators;
using Barcode.GraphQL.Types.Product;
using Barcode.GraphQL.Types.Product.Input;
using Barcode.GraphQL.Types.Response;
using GraphQL.Types;
using MongoDB.Bson;

namespace Barcode.GraphQL.Resolvers
{
    public class ProductMutationResolver : Resolver, IProductMutationResolver
    {
        private readonly IProductService _productService;

        public ProductMutationResolver(IProductService productService)
        {
            _productService = productService;
        }

        public void Resolve(Mutation productQuery)
        {
            productQuery.Field<ResponseGraphType<ProductIdType>>(
                "AddProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInformationInputType>> { Name = "ProductInformation", Description = "Id of the product" },
                    new QueryArgument<ProductDetailsInputType> { Name = "ProductDetail", Description = "Id of the product" },
                    new QueryArgument<ProductAdditionalInputType> { Name = "ProductAdditional", Description = "Id of the product" }
                    ),
                resolve: context =>
               {
                   var product = new Product
                   {
                       ProductInformation = context.GetArgument<ProductInformation>("productInformation"),
                       ProductDetail = context.GetArgument<ProductDetail>("productDetail"),
                       ProductAdditionalDetail = context.GetArgument<ProductAdditionalDetail>("productAdditionalDetail")
                   };
                   return Response(new ProductId { Id = ObjectId.GenerateNewId().ToString() });
                }

            );

            productQuery.Field<ResponseGraphType<BooleanGraphType>>(
                "UpdateProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInformationInputType>> { Name = "ProductInformation", Description = "Id of the product" },
                    new QueryArgument<ProductDetailsInputType> { Name = "ProductDetail", Description = "Id of the product" },
                    new QueryArgument<ProductAdditionalInputType> { Name = "ProductAdditional", Description = "Id of the product" }
                ),
                resolve: context =>
                {
                    var product = new Product
                    {
                        ProductInformation = context.GetArgument<ProductInformation>("productInformation"),
                        ProductDetail = context.GetArgument<ProductDetail>("productDetail"),
                        ProductAdditionalDetail = context.GetArgument<ProductAdditionalDetail>("productAdditionalDetail")
                    };

                    return Response(true);
                }

            );
        }


    }
}