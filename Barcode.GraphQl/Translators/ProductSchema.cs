using GraphQL;
using GraphQL.Types;

namespace Barcode.GraphQL.Translators
{
    public class ProductSchema : Schema
    {
        public ProductSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<Query>();  
            Mutation = resolver.Resolve<Mutation>();
        }
    }
}