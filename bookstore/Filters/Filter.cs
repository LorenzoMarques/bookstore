using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using bookstore.Exceptions;

namespace bookstore.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is HttpException httpException)
            {
                var response = new
                {
                    message = httpException.Message,
                    error = httpException.StatusCode
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = (int)httpException.StatusCode
                };
            }
            else
            {
                var response = new { message = "Unexpected error" };
                Console.WriteLine(context.Exception);
                context.Result = new ObjectResult(response)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

            context.ExceptionHandled = true;
        }
    }
}
