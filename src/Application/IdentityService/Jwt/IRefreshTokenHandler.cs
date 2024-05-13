using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.IdentityService.Jwt
{
    public interface IRefreshTokenHandler
    {
        public string Generate(int length);
    }
}
