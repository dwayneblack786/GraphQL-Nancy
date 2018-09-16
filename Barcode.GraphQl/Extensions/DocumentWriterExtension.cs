using GraphQL;
using GraphQL.Types;
using Nancy;
using Request = Barcode.GraphQL.Translators.Request;

namespace Barcode.GraphQL.Extensions
{
    public static class DocumentWriterExtension
    {
        public static ExecutionResult Configure(this ExecutionResult result)
        {
            result.Document = null;
            result.Operation = null;
            result.ExposeExceptions = false;
            result.Perf = null;
            result.Query = null;
            return  result;
        }


        public static ExecutionOptions Configure(this Request request, ISchema schema, NancyContext context)
        {
            return new ExecutionOptions
            {
                Schema = schema,
                Query = request.Query,
                UserContext = context.CurrentUser
            };
        }

    }
}
