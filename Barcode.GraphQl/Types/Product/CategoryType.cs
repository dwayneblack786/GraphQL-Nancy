using Barcode.Common.Model.Product;
using Barcode.GraphQL.Contracts;
using GraphQL.Types;

namespace Barcode.GraphQL.Types.Product
{
    public class CategoryType : ObjectGraphType<Category>, IGraphQlType
    {
        public CategoryType()
        {
            Field(x => x.DisplayName).Description("Category Name");
            Field(x => x.Value).Description("Category Value");
        }
    }
}