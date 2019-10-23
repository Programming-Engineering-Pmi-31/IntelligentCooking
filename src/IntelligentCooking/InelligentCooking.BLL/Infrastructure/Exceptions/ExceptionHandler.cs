using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

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
            throw new ValidationException(errors.Select(e => e.Description));
        }

        public static void InvalidPasswordException()
        {
            throw new ValidationException(new[] {Constants.Constants.WrongPasswordErrorMessage()});
        }

        public static void TokenNotExpired()
        {
            throw new ValidationException(new[] { Constants.Constants.TokenNotExpiredErrorMessage()});
        }

        public static void InvalidTokenException()
        {
            throw new SecurityTokenException(Constants.Constants.InvalidTokenErrorMessage());
        }
    }
}
