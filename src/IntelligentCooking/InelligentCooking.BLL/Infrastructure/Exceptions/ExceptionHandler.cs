using System.Collections.Generic;

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
    }
}
