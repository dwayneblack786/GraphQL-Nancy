using Barcode.Common.Model.Generic;
using Barcode.GraphQL.Contracts;
using GraphQL.Types;

namespace Barcode.GraphQL.Types.Product.Input
{
    public class NutritionFactsDictionaryGraphInputType : InputObjectGraphType<NameValuePair>, IGraphQlType
    {
        public NutritionFactsDictionaryGraphInputType()
        {
            Name = "Ingredients";

            Field(x => x.Name).Description("extension of file stored");
            Field(x => x.Value).Description("extension of file stored");
        }
    }
}