using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using StockManager.Aplication.Responses;

namespace StockManager.Filters;

public class CustomExeptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case ValidationException validationException:
                var errors = validationException.Errors.Select(error => $"{error.ErrorMessage}").ToList();
                if (errors.Any() && !string.IsNullOrEmpty(context.Exception.Message))
                    errors.Add(context.Exception.Message);
                var result = new ObjectResult(new GenericResponseNoData()
                {
                    Errors = errors.ToArray()
                })
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
                context.Result = result;
                context.ExceptionHandled = true;
                break;
        }
    }
}