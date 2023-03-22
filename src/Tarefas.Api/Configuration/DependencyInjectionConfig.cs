using Elmah.Io.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Tarefas.Api.RabitMQ;
using Tarefas.Business.Interfaces;
using Tarefas.Business.Notificacoes;
using Tarefas.Business.RabitMQ;
using Tarefas.Business.Services;
using Tarefas.Data.Context;
using Tarefas.Data.Repository;

namespace Tarefas.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DbContextApp>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddTransient<ITarefaService, TarefaService>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddScoped<IRabitMQProducer, RabitMQProducer>();
            services.AddScoped<IRabitMQConsumer, RabitMQConsumer>();

            services.AddLogging(provider =>
            {
                provider.AddElmahIo(options =>
                {
                    options.ApiKey = "753d2495d5674e2aa75302aa94e934d0";
                    options.LogId = new Guid("b3a7cda3-b343-4f39-9df2-8f6ffbfd1947");
                });
                provider.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });

            return services;
        }

    }
}
