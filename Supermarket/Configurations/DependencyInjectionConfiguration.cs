using Supermarket.Contrats.Interfaces.IRepositories;
using Supermarket.Contrats.Interfaces.Services;
using Supermarket.Core.Services;
using Supermarket.Infraestrutura.Repositories;

namespace Supermarket.Configurations
{
    public static  class DependencyInjectionConfiguration
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection service)
        {
            #region Repositories
            service.AddScoped<ICustomerRepository, CustomerRepository>();

            #endregion

            #region Services

            service.AddScoped<ICustomerService, CustomerService>();
            #endregion


            return service;

        }
    }
}
