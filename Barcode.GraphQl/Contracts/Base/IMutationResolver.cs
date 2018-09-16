using Barcode.GraphQL.Translators;

namespace Barcode.GraphQL.Contracts.Base
{
    public interface IMutationResolver
    {

        void Resolve(Mutation productQuery);
    }
}