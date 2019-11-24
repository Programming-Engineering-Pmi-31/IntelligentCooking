using System;

namespace InelligentCooking.BLL.Infrastructure.Exceptions
{
    public class DublicateObjectException : Exception
    {
        public DublicateObjectException(string message)
            : base(message)
        {
        }
    }
}
