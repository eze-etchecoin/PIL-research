using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace ChatGPT_API.Services
{
    static class ApiKey
    {
        public const string Name = "ApiKey";
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

    public class ApiKeyAttribute : Attribute, IAsyncActionFilter

    {
        public async Task OnActionExecutionAsync

        (ActionExecutingContext context, ActionExecutionDelegate next)

        {

            if (!context.HttpContext.Request.Headers.TryGetValue

              (ApiKey.Name, out var extractedApiKey))

            {

                context.Result = new ContentResult()

                {

                    StatusCode = 401,

                    Content = "Api Key was not provided"

                };

                return;

            }
            var appSettings =

              context.HttpContext.RequestServices.GetRequiredService<IConfiguration>(); var apiKey = appSettings.GetValue<string>(ApiKey.Name); if (!apiKey.Equals(extractedApiKey))

            {

                context.Result = new ContentResult()

                {

                    StatusCode = 401,

                    Content = "Api Key is not valid"

                };

                return;

            }
            await next();

        }

    }

    public class AddRequiredApiKeyHeaderParameter : IOperationFilter

    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)

        {

            if (context.MethodInfo?.DeclaringType?.GetCustomAttribute(typeof(ApiKeyAttribute)) is ApiKeyAttribute ||

              context.MethodInfo?.GetCustomAttribute(typeof(ApiKeyAttribute)) is ApiKeyAttribute)

            {
                operation.Parameters ??= new List<OpenApiParameter>(); operation.Parameters.Add(new OpenApiParameter

                {

                    Name = ApiKey.Name,

                    In = ParameterLocation.Header,

                    Required = true,

                    Schema = new OpenApiSchema

                    {

                        Type = "string"

                    }

                });

            }

        }
    }

}
