using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ResponseStatus
{
    public enum ResponseStatusCode
    {
        NEW_PASSWORD_IS_NOT_VALID,
        RESET_PASSWORD_TOKEN_IS_NOT_FOUND,
        INPUT_VALIDATION_FAIL,
        OPERATION_SUCCESS,
        DATABASE_OPERATION_FAIL,
        USER_IS_TEMPORARILY_REMOVED,
        USER_ID_IS_NOT_FOUND,
        UN_AUTHORIZED,
        FORBIDDEN,
        INPUT_NOT_UNDERSTANDABLE,
        LIMIT_ONE_MATCH_PER_DAY,
        PRESTIGE_IS_NOT_ENOUGH
    }
}
