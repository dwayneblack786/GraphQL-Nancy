using Barcode.Common.Model.Product;
using Barcode.GraphQL.Contracts;
using GraphQL.Types;

namespace Barcode.GraphQL.Types.Product
{
    public class ProductType : ObjectGraphType<ProductCollection>, IGraphQlType
    {
        public ProductType()
        {
            Field(x => x.Id).Description("Id for the product saved");
            Field(x => x.Barcode).Description("Scanned Barcode.");
            Field(x => x.IsBarcodeUpdated).Description("Was the barcode updated");
            Field(x => x.IsDeleted).Description("Is item Deleted");
            Field(x => x.UpdatedBarcode).Description("Updated Barcode ");
            Field<CategoryType>(
                "Category",
                "Category for products.",
                resolve: context => context.Source.ProductChain
            );
            Field<ListGraphType<BlockType>>(
                "Blocks",
                "Blocks of the Chain List.",
                resolve: context => context.Source.ProductChain
            );
            Field<ListGraphType<ProductDocumentStreamType>>(
                "Documents",
                "Documents of the Chain List.",
                resolve: context => context.Source.ProductDocuments
            );
        }
    }

  
}
