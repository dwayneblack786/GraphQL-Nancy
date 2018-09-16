using Barcode.GraphQL.Translators;

namespace Barcode.GraphQL.Contracts.Base
{
    public interface IResolver
    {
        void Resolve(Query productQuery);
    }
}