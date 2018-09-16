using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Barcode.Common.Model.Configuration;
using Barcode.GraphQL.Contracts;
using Barcode.GraphQL.Resolvers;
using Barcode.GraphQL.Services;
using Barcode.GraphQL.Translators;
using Barcode.GraphQL.Types.Response;
using GraphQL.Types;
using Microsoft.Extensions.Options;

namespace Barcode.GraphQL.Configurations
{
    public class DiManager
    {
        public static IContainer AppContainer;

        static DiManager()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            AppContainer = builder.Build();
        }

        public class ProductServiceModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.Register(ctx =>
                {
                    var config = ctx.Resolve<IOptions<Application>>();
                    return new ProductService(config);
                }).As<IProductService>().SingleInstance();
            }
        }

        public class ProductResolverModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                
                builder.Register(ctx =>
                {
                    var service = ctx.Resolve<IProductService>();
                    return new ProductQueryResolver(service);
                }).AsSelf().SingleInstance();
                builder.Register(ctx =>
                {
                    var service = ctx.Resolve<IProductService>();
                    return new ProductMutationResolver(service);
                }).AsSelf().SingleInstance();
            }
        }

        public class GraphQlModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<Query>().AsSelf().SingleInstance();
                builder.RegisterType<Mutation>().AsSelf().SingleInstance();
                builder.RegisterType<ProductSchema>().As<ISchema>().SingleInstance();
                builder.RegisterGeneric(typeof(ResponseGraphType<>)).AsSelf().SingleInstance();
                builder.RegisterGeneric(typeof(ResponseListGraphType<>)).AsSelf().SingleInstance();


                var serviceAssembly = typeof(GraphQlModule).GetTypeInfo().Assembly;
                builder.RegisterAssemblyTypes(serviceAssembly)
                    .Where(t => t.GetInterfaces()
                        .Any(i => i.IsAssignableFrom(typeof(IGraphQlType))))
                    .AsSelf();
 
                builder.RegisterAssemblyTypes(serviceAssembly)
                    .Where(t => t.Name.EndsWith("Resolver", StringComparison.Ordinal) && t.Name != "Resolver")
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            }
        }



    }
}
