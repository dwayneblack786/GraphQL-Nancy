using Barcode.Common.Model.Product;
using Barcode.GraphQL.Contracts;
using GraphQL.Types;

namespace Barcode.GraphQL.Types.Product.Input
{
    public class ProductDetailsInputType : InputObjectGraphType<ProductDetail>, IGraphQlType
    {
        public ProductDetailsInputType()
        {
            Name = "ProductDetail";

          
            Field(x => x.Mpn).Description("extension of file stored");
            Field(x => x.Model).Description("extension of file stored");
            Field(x => x.Asin).Description("extension of file stored");
            Field(x => x.Title).Description("extension of file stored");
            Field(x => x.Manufacturer).Description("extension of file stored");
            Field(x => x.Label).Description("extension of file stored");
            Field(x => x.Author).Description("extension of file stored");
            Field(x => x.Publisher).Description("extension of file stored");
            Field(x => x.Artist).Description("extension of file stored");
            Field(x => x.Actor).Description("extension of file stored");
            Field(x => x.Director).Description("extension of file stored");
            Field(x => x.Studio).Description("extension of file stored");
            Field(x => x.Genre).Description("extension of file stored");
            Field(x => x.Audience).Description("extension of file stored");
            Field(x => x.Color).Description("extension of file stored");
            Field(x => x.PackageQuantity).Description("extension of file stored");
            Field(x => x.Size).Description("extension of file stored");
            Field(x => x.Length).Description("extension of file stored");
            Field(x => x.Width).Description("extension of file stored");
            Field(x => x.Height).Description("extension of file stored");
            Field(x => x.Weight).Description("extension of file stored");
            Field(x => x.ReleaseDate).Description("extension of file stored");
           
        }

    }
}