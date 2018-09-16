using System;
using System.Linq;
using Barcode.GraphQL.Contracts.Base;
using GraphQL.Types;

namespace Barcode.GraphQL.Translators
{
    public class Query : ObjectGraphType
    {
        public Query(IServiceProvider serviceProvider)
        {
            var type = typeof(IResolver);
            var resolversTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var resolverType in resolversTypes)
            {
                var resolverTypeInterface = resolverType.GetInterfaces().FirstOrDefault(x => x != type);
                if (resolverTypeInterface == null) continue;
                var resolver = serviceProvider.GetService(resolverTypeInterface) as IResolver;
                resolver?.Resolve(this);
            }
        }
    }
}
