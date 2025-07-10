using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MultiTenantSystem.API
{
    public static class SwaggerGenOptionsExtensions
    {
        public static void AddSwaggerGenOptionsWithBearerPrefix(this SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer' [space] and then your token:\n\nExample: **Bearer eyJhbGciOiJIUzI1NiIs...**"
            });
        }
    }
}
