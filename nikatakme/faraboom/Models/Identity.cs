using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace faraboom.Models
{
    public static class Identity
    {
        public static string GetId(this IIdentity identity)
        {
            ClaimsIdentity ClimsIdentity = identity as ClaimsIdentity;
            Claim claim = ClimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value ?? string.Empty;
        }
    }
}
