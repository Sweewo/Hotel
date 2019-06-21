using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Hotel.Web.Api.Helpers
{
    public class IdFromClaimsResolver
    {
        public static int Resolve(HttpContextAccessor httpContextAccessor)
        {
            return int.Parse(((System.Security.Claims.ClaimsIdentity)((DefaultHttpContext)((HttpContextAccessor)httpContextAccessor)
              .HttpContext).User.Identity).Claims.FirstOrDefault(c => c.Type.Equals("id")).Value);
        }
    }
}
