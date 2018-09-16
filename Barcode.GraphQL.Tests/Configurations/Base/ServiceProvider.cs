using System.IO;
using Barcode.Common.Model.Configuration;
using Barcode.GraphQL.Configurations;
using GraphQL;
using GraphQL.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Path = System.IO.Path;

namespace Barcode.GraphQL.Tests.Configurations.Base
{
    public class ServiceProvider
    {
        public IConfigurationRoot Configuration { get; set; }
        public ServiceCollection ServiceCollection { get; }

        public ServiceProvider()
        {
            var wantedPath =
                Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
            IHostingEnvironment env = new HostingEnvironment { ContentRootPath = wantedPath };

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(Configuration);
            services.Configure<Application>(Configuration.GetSection("Application"));
            services.AddLogging();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    b => b.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
            ServiceCollection = services;
            var bs = new BootstrapManager(services);
        }
    }
}