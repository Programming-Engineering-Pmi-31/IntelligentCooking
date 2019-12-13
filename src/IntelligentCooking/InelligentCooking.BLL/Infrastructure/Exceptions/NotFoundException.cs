using System;

namespace InelligentCooking.BLL.Infrastructure.Exceptions
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) {}
    }
}
