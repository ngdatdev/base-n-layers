using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.ApiResponse
{
    public class ErrorHttpResponse
    {
        [JsonIgnore]
        public int HttpCode { get; init; }
            
        public IEnumerable<string> ErrorMessages { get; init; } = [];
    }
}
