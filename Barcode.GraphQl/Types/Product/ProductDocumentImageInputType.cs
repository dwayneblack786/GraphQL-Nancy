using Barcode.Common.Model.Product;
using Barcode.GraphQL.Contracts;
using GraphQL.Types;

namespace Barcode.GraphQL.Types.Product
{
    public class ProductDocumentImageInputType : InputObjectGraphType<ProductDocumentStream>, IGraphQlType
    {
        public ProductDocumentImageInputType()
        {
            Field(x => x.Extension).Description("extension of file stored");
            Field(x => x.FileName).Description("Name of file");
            Field(x => x.FileStream).Description("Byte array for file converted to base64");
        }
    }
}