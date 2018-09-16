using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Configuration;
using Nancy.Diagnostics;

namespace Barcode.GraphQL.Configurations
{
    public class BootstrapManager : AutofacNancyBootstrapper
    {
        private readonly IServiceCollection _services;
        //private readonly ILoggerFactory _loggerFactory;

        public BootstrapManager(IServiceCollection services)
        {
            _services = services;
        }

        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {



            pipelines.OnError += (ctx, ex) =>
            {

                //logger.LogError("location", ex);

                return null;
            };


            pipelines.BeforeRequest += (ctx) =>
            {
                //ogger.LogInformation("location microservice before request response", ctx);
                // Log.Information<NancyContext>("location microservice before request response", ctx);
                return null;
            };

            // your customization goes here
            pipelines.AfterRequest.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response
                    .WithHeader("Access-Control-Allow-Origin", "*")
                    .WithHeader("Access-Control-Allow-Methods", "PUT, GET, POST, DELETE")
                    .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type")
                    .WithHeader("Access-Control-Allow-Headers", "Content-type")
                    .WithHeader("Allow", "POST, GET, DELETE, PUT");
            });

            pipelines.AfterRequest += (ctx) =>
            {
                //logger.LogInformation("location microservice after request response", ctx);
                // Log.Information<NancyContext>("location microservice after request response", ctx);
            };


        }



        public override void Configure(INancyEnvironment environment)
        {
            environment.Diagnostics(true, "password");
            environment.Tracing(true, true);

            base.Configure(environment);

        }

        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);
            existingContainer.Update(builder => { builder.Populate(_services); });
        }

        protected override ILifetimeScope GetApplicationContainer()
        {
            return DiManager.AppContainer;
        }
    }
}
