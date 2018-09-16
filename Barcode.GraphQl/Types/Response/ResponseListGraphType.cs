using GraphQL.Types;

namespace Barcode.GraphQL.Types.Response
{
    public class ResponseListGraphType<TGraphType> : ObjectGraphType<Common.Model.GraphQl.Response> where TGraphType : GraphType
    {
        public ResponseListGraphType()
        {
            Name = $"ResponseList{typeof(TGraphType).Name}";

            Field(x => x.StatusCode, true).Description("Status code of the request.");
            Field(x => x.ErrorMessage, true).Description("Error message if requests fails.");

            Field<ListGraphType<TGraphType>>(
                "data",
                "Product data returned by query.",
                resolve: context => context.Source.Data
            );
        }
    }
}