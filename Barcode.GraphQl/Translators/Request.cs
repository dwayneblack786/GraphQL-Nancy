using Newtonsoft.Json.Linq;

namespace Barcode.GraphQL.Translators
{
    public class Request
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
        public string NamedQuery { get; set; }
    }
}