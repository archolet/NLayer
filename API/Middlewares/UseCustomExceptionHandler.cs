﻿using Core.DTOs;
using Microsoft.AspNetCore.Diagnostics;
using Service.Exceptions;
using System.Text.Json;

namespace API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app) {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statuscode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statuscode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statuscode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));



                });
            });
        }
    }
}
