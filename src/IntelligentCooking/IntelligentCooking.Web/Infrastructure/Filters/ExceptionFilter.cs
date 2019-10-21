using System;
using System.Net;
using InelligentCooking.BLL.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IntelligentCooking.Web.Infrastructure.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            switch (context.Exception)
            {
                case NotFoundException ex:
                    context.Result = new NotFoundObjectResult(ex.Message);
                    break;
                case DublicateObjectException ex: 
                    context.Result = new ConflictObjectResult(ex.Message);
                    break;
                default:
                    context.Result = new BadRequestResult();
                    break;
            }

            context.Exception = null;
            base.OnException(context);
        }
    }
}
