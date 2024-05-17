using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Request;

public class LoginRequest
{
    public string Username { get; init; }
    public string Password { get; init; }
    public bool IsRemember { get; init; }
}
