using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ResponseStatus
{
    public sealed class ResponseEntity<T>
        where T : class
    {
        public T Body { get; init; }

        public ResponseStatusCode StatusCode { get; init; }
    }
}
