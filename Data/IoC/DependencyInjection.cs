using Application.Interfaces;
using Application.Services;
using Data.Repositories;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class DependencyInjection
    {
        public static void AddConfigurations(IServiceCollection services)
        {

            //Repositories
            services.AddTransient<IInvestmentRepository, InvestmentRepository>();
            //Services
            services.AddTransient<IInvestmentService<InvestmentTdsService>, InvestmentTdsService>();
            services.AddTransient<IInvestmentService<InvestmentLcisService>, InvestmentLcisService>();
            services.AddTransient<IInvestmentService<InvestmentFundsService>, InvestmentFundsService>();
            services.AddTransient<IInvestmentApp, InvestmentApp>();
        }
    }
}
