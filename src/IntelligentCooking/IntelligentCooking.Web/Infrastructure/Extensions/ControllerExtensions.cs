using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentCooking.Web.Infrastructure.Extensions
{
    public static class ControllerExtension
    {
        public static int GetContactId(this Controller controllerBase)
        {
            return Int32.Parse(
                controllerBase.User.Claims.FirstOrDefault(c => c.Type == "id")
                    .Value);
        }
    }
}
