using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Application.IdentityService.Jwt.Handler
{
    public class RefreshTokenHandler : IRefreshTokenHandler
    {
        public string Generate(int length)
        {
            const string Chars =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz!@#$%^&*+=";

            if (length < RefreshToken.MetaData.RefreshTokenValue.MinLength)
            {
                return string.Empty;
            }

            StringBuilder builder = new();

            for (int time = default; time < length; time++)
            {
                builder.Append(
                    value: Chars[index: RandomNumberGenerator.GetInt32(toExclusive: Chars.Length)]
                );
            }

            return builder.ToString();
        }
    }
}
