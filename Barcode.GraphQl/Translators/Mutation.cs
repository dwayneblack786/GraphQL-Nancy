using System;
using System.Linq;
using Barcode.GraphQL.Contracts.Base;
using GraphQL.Types;

namespace Barcode.GraphQL.Translators
{
    public class Mutation : ObjectGraphType<object>
    {
        public Mutation(IServiceProvider serviceProvider)
        {
            var type = typeof(IMutationResolver);
            var mutationResolversTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var resolverType in mutationResolversTypes)
            {
                var resolverTypeInterface = resolverType.GetInterfaces().FirstOrDefault(x => x != type);
                if (resolverTypeInterface == null) continue;
                var mutationResolver = serviceProvider.GetService(resolverTypeInterface) as IMutationResolver;
                mutationResolver?.Resolve(this);
            }
        }
    }
}