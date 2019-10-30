using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AsyncOData
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ApplyExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var errorFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    var problemDetails = new ProblemDetails
                    {
                        Title = "Unexpected Error",
                        Status = context.Response.StatusCode,
                        Detail = $"{exception.Message} {exception.InnerException?.Message}"
                    };

                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.StatusCode = problemDetails.Status.GetValueOrDefault();
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));

                    await Task.CompletedTask;
                });
            });

            return app;
        }
    }
}
