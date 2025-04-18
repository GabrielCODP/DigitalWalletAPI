﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CardDigitalAPI.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;
        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Ocorreu um exceção não tratada: Status code 500");

            context.Result = new ObjectResult("Ocorreu um problema ao tratar a sua solicitação")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
