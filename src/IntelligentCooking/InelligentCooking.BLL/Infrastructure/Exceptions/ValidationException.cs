using System;
using System.Collections.Generic;

namespace InelligentCooking.BLL.Infrastructure.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<string> additionalData)
        {
            Data["Error"] = additionalData;
        }
    }
}
