using System.Security.Claims;

namespace Barcode.GraphQL.Translators
{
    public class UserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}