using System;
using System.Threading.Tasks;
using Barcode.GraphQL.Extensions;
using GraphQL;
using GraphQL.Types;
using Nancy;
using Nancy.ModelBinding;
using Request = Barcode.GraphQL.Translators.Request;

namespace Barcode.GraphQL.Modules
{
    public sealed class HomeModule : NancyModule
    {
        public HomeModule(IDocumentExecuter documentExecutor, ISchema schema)
        {
            Get("/", async (x, ct) =>
            {
                var route = $"{Request.Url.BasePath}/index.html";
                return await Task.Run(() => Response.AsRedirect(route));
            });

            Post("/api/graphql", async (x, ct) =>
            {
                try
                {
                    var request = (this).Bind<Request>();
                    var result = await documentExecutor.ExecuteAsync(request.Configure(schema, Context)).ConfigureAwait(false);
                    return result.Configure();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }


            }, null, "RequestBarcodeScannerData");
        }
    }
}
