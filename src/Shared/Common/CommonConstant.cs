using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Common;

/// <summary>
///     Represent set of constant.
/// </summary>
public static class CommonConstant
{
    public static class App
    {
        public static readonly Guid DEFAULT_ENTITY_ID_AS_GUID = Guid.Parse(
            input: "c8500b46-b134-4b60-85b7-8e6af1187e1c"
        );
    }
}
