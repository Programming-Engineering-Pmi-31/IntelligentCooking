using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace InelligentCooking.BLL.Infrastructure.Exceptions
{
    public class RegistrationException: Exception
    {
        public RegistrationException(IEnumerable<IdentityError> errors)
        {
            Data["Errors"] = errors;
        }
    }
}
