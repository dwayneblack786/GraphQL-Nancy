using Barcode.Common.Model.Product;
using Barcode.GraphQL.Contracts;
using GraphQL.Types;

namespace Barcode.GraphQL.Types.Product.Input
{
    public class ProductAdditionalInputType : InputObjectGraphType<ProductAdditionalDetail>, IGraphQlType
    {
        public ProductAdditionalInputType()
        {
            Name = "ProductAdditionalDetail";
            Field<ListGraphType<NutritionFactsDictionaryGraphInputType>>(
                "NutritionFacts",
                "NutritionFacts of Product.",
                resolve: context => context.Source.NutritionFacts
            );
            Field<ListGraphType<StringGraphType>>(
                "Ingredients",
                "Ingredients of Product.",
                resolve: context => context.Source.Ingredients
            );
            Field<ListGraphType<StringGraphType>>(
                "Features",
                "Features of Product.",
                resolve: context => context.Source.Features
            );
            Field<ListGraphType<ProductDocumentImageInputType>>(
                "Images",
                "Images of Product.",
                resolve: context => context.Source.Images
            );
            Field<ListGraphType<StringGraphType>>(
                "Stores",
                "Stores available of Product.",
                resolve: context => context.Source.Stores
            );
            Field<ListGraphType<StringGraphType>>(
                "Reviews",
                "Reviews of Product.",
                resolve: context => context.Source.Reviews
            );

        }
    }
}