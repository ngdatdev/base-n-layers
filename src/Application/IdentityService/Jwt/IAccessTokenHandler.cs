using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.IdentityService.Jwt
{
    public interface IAccessTokenHandler
    {
        public string GenerateSigningToken(IEnumerable<Claim> claims);
    }
}
