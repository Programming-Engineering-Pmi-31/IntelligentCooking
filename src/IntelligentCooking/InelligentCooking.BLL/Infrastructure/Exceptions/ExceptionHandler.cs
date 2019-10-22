using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace InelligentCooking.BLL.Infrastructure.Exceptions
{
    public static class ExceptionHandler
    {
        public static void NotFound(string entity)
        {
            throw new NotFoundException(Constants.Constants.NotFoundErrorMessage(entity));
        }

        public static void DublicateObject(string entity, string property)
        {
            throw new DublicateObjectException(Constants.Constants.DublicateObjectErrorMessage(entity, property));
        }

        public static void RegistrationException(IEnumerable<IdentityError> errors)
        {
            throw new RegistrationException(errors);
        }

        public static void LoginFailedException()
        {
            throw new LoginFailedException(Constants.Constants.WrongPasswordErrorMessage());
        }
    }
}
