using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace H4TexasHoldEmV2
{
    public static class SocketExtension
    {
        public static IServiceCollection AddWebSocketManager(this IServiceCollection services)
        {
            services.AddTransient<ConnectionManager>();
            foreach (var type in Assembly.GetEntryAssembly().ExportedTypes)
            {
                if (type.GetTypeInfo().BaseType == typeof(SocketHandler))
                {
                    services.AddSingleton(type);
                }
            }

            return services;
        }

        public static IApplicationBuilder MapSockets(this IApplicationBuilder app, PathString path, SocketHandler socket)
        {
            return app.Map(path, (x) => x.UseMiddleware<SocketMiddleWare>(socket));
        }
    }
}
