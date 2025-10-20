using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Auth.Utils.Filters
{
    public class AuthOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var Attributes = context.ApiDescription.CustomAttributes();
            bool IsAuthorize = Attributes.Any(attribute => attribute.GetType() == typeof(AuthorizeAttribute));
            bool IsAllowAnonymus = Attributes.Any(attribute => attribute.GetType() == typeof(AllowAnonymousAttribute));

            if (!IsAuthorize || IsAllowAnonymus) return;

            var reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Token"
            };

            var securityScheme = new OpenApiSecurityScheme
            {
                Reference = reference
            };

            var requierement = new OpenApiSecurityRequirement
            {
                [securityScheme] = []
            };

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                requierement
            };
        }
    }
}
