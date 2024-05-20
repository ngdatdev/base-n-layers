using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Middleware
{
    internal sealed class GlobalValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            
        }
    }
}
