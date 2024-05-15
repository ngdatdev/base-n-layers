using System;

namespace WebAPI.Attribute.JwtAttribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RequireJwtAttribute : System.Attribute { }
