using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ResponseStatus;

/// <summary>
///     The response status app code for <see cref="ResponseEntity"/>
/// </summary>
public enum ResponseStatusCode
{
    OPERATION_SUCCESS,
    INPUT_VALIDATION_FAIL,
    USER_ID_IS_NOT_FOUND,
    USERNAME_IS_NOT_FOUND,
    DATABASE_OPERATION_FAIL,
    USER_IS_LOCKED_OUT,
    PASSWORD_IS_NOT_CORRECT,
    UN_AUTHORIZED,
    FORBIDDEN,
    NEW_PASSWORD_IS_NOT_VALID,
    RESET_PASSWORD_TOKEN_IS_NOT_FOUND,
    USER_IS_TEMPORARILY_REMOVED,
    INPUT_NOT_UNDERSTANDABLE,
}
