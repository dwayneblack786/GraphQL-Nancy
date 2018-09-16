using GraphQL.Types;

namespace Barcode.GraphQL.Types.Response
{
    public class ResponseGraphType<TGraphType> : ObjectGraphType<Common.Model.GraphQl.Response> where TGraphType : GraphType
    {
        public ResponseGraphType()
        {
            Name = $"Response{typeof(TGraphType).Name}";
            Field(x => x.StatusCode, true).Description("Status code of the request.");
            Field(x => x.ErrorMessage, true).Description("Error message if requests fails.");
            Field<TGraphType>(
                "data",
                "ProductDetail returned by query.",
                resolve: context => context.Source.Data
            );
        }
    }
}
