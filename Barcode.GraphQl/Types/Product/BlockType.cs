using Barcode.Common.Model.BlockChain;
using Barcode.GraphQL.Contracts;
using GraphQL.Types;

namespace Barcode.GraphQL.Types.Product
{
    public class BlockType : ObjectGraphType<Block>, IGraphQlType
    {
        public BlockType()
        {
            Field(x => x.Data).Description("ProductDetail stored");
            Field(x => x.Index).Description("Sequence of block");
            Field(x => x.TimeStamp).Description("Time block was created");
        }
    }
}