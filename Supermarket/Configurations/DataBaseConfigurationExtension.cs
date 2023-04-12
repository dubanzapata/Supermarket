using Microsoft.EntityFrameworkCore;
using Supermarket.Infraestrutura;

namespace Supermarket.Configurations
{
    public static class DataBaseConfigurationExtension
    {
        public static IServiceCollection DataBaseConfiguration(this IServiceCollection builder)
        {
            builder.AddDbContext<SupermarketDbContext>(x => x.UseSqlServer("Data Source = MNB508\\SQLEXPRESS; Initial Catalog = Supermarket; User ID = sa;Password=Dios7777777"));
            
            return builder;

        }
       

    }
}
