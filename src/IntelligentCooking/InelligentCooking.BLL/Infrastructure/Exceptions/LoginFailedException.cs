using System;

namespace InelligentCooking.BLL.Infrastructure.Exceptions
{
    public class LoginFailedException: Exception
    {
        public LoginFailedException(string message): base(message)
        {
        }   
    }
}
