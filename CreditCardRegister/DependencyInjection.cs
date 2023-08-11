using CreditCardRegister.API.Common.Errors;
using CreditCardRegister.API.Common.Mappling;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CreditCardRegister.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, CreditCardRegisterProblemDetailsFactory>();
            services.AddMappings();
            return services;
        }
    }
}