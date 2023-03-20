using Tarefas.Api.Configuration;

namespace Tarefas.Api
{
    public interface IStartup
    {
        void ConfigureServices(IServiceCollection services);
        public void Configure(WebApplication app, IWebHostEnvironment env);
        IConfiguration Configuration { get; }
    }


    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }
        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(webHostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{webHostEnvironment.EnvironmentName}.json")
                .AddEnvironmentVariables();

            if (webHostEnvironment.IsProduction())
            {
                builder.AddUserSecrets<Startup>();
            }
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfig(Configuration);
            services.AddAutoMapper(typeof(Startup));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfig();
            services.ResolveDependencies();
            services.AddApiConfig();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseApiConfig(env);
            app.UseSwaggerConfig();
            app.UseElmahIoExtensionsLogging();
        }
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), webAppBuilder.Environment) as IStartup;
            if (startup == null) throw new Exception("Classe Starup.cs inválida");

            startup.ConfigureServices(webAppBuilder.Services);
            var app = webAppBuilder.Build();

            startup.Configure(app, app.Environment);
            app.Run();

            return webAppBuilder;
        }
    }
}
