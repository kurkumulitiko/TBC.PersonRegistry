namespace TBC.PersonRegistry.API.Extensions
{
    public static class SwaggerConfiguration
    {

        // services
        public static void AddSwaggerServices(this IServiceCollection services)
        {
           // services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>{

                // კომენტარების დაყენება Swagger JSON და UI–თვის.
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "SwaggerDescription.xml");
                options.IncludeXmlComments(xmlPath);

            });
        }


        // middleware
        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.InjectStylesheet("/SwaggerDark.css"); 
            });

            return app;
        }
    }
}
