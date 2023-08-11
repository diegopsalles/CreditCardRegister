using CreditCardRegister.API.Common.Errors;
using CreditCardRegister.API.Common.Mappling;
using CreditCardRegister.Application.Common.Interfaces.Authentication;
using CreditCardRegister.Application.Common.Interfaces.Persistance;
using CreditCardRegister.Infrastructure.Authentication;
using CreditCardRegister.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;

namespace CreditCardRegister.API
{
    public static class DependencyInjection
    {
        public static void InjectProcessorServices(IServiceCollection services, IConfiguration configuration, Serilog.ILogger logger)
        {
            services.AddControllers();
            
            services.AddSingleton<ProblemDetailsFactory, CreditCardRegisterProblemDetailsFactory>();
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            
            services.Configure<JWTSettings>(configuration.GetSection(JWTSettings.SectionName));
            
            services.AddSingleton<IJWTTokenGenerator, JWTTokenGenerator>();
            
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddMappings();

            services.AddDbContext<ExportacaoDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("iMusicaExportacao"));
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.LogTo(Console.WriteLine, LogLevel.Error);
            });

            services.AddDbContext<MetaDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("iMusicaMeta"));
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.LogTo(Console.WriteLine, LogLevel.Error);
            });
        }
    }
}