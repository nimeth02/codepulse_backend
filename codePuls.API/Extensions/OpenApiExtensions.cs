namespace codePuls.API.Extensions
{
    public static class OpenApiExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            object value = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "CodePuls API",
                    Version = "v1"
                });
            });

            return services;
        }

        public static void UseSwaggerDocumentation(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodePuls API v1");
                c.RoutePrefix = string.Empty; // Swagger UI at root URL (e.g., https://localhost:5001/)
            });
        }
    }
}
