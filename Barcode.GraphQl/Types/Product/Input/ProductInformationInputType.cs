using Barcode.Common.Model.Product;
using Barcode.GraphQL.Contracts;
using GraphQL.Types;

namespace Barcode.GraphQL.Types.Product.Input
{
    public class ProductInformationInputType : InputObjectGraphType<ProductInformation>, IGraphQlType
    {
        public ProductInformationInputType()
        {
            Name = "ProductInformation";
            Field(x => x.Barcode).Description("extension of file stored");
            Field(x => x.BarcodeType).Description("extension of file stored");
            Field(x => x.BarcodeFormats).Description("extension of file stored");
            Field(x => x.ProductName).Description("extension of file stored");
            Field(x => x.Description).Description("extension of file stored");
            Field(x => x.Category).Description("extension of file stored");
            Field(x => x.Brand).Description("extension of file stored");


        }
    }
}