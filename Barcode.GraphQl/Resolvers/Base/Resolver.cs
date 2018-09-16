using Barcode.Common.Model.GraphQl;
using Barcode.Common.Model.GraphQl.Error;

namespace Barcode.GraphQL.Resolvers.Base
{
    public class Resolver
    {
        public Response Response<T>(T data)
        {
            return new Response(data);
        }

        public   Response Error(GraphQlError error)
        {
            return   new Response(error.StatusCode, error.ErrorMessage);
        }

        public Response AccessDeniedError()
        {
            var error = new AccessDeniedError();
            return new Response(error.StatusCode, error.ErrorMessage);
        }

        public Response NotFoundError(string id)
        {
            var error = new NotFoundError(id);
            return new Response(error.StatusCode, error.ErrorMessage);
        }
    }
}
