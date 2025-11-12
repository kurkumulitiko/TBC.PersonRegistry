using TBC.PersonRegistry.API.Extensions;

namespace TBC.PersonRegistry.API
{
    public static class DependencyInjection
    {
        public static void AddThisLayer(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerServices();
        }
    }
}
