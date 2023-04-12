
using Microsoft.EntityFrameworkCore;
using Supermarket.Dto.Models;

namespace Supermarket.Infraestrutura
{
    public class SupermarketDbContext:DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext>options):base(options)
        {
            
            }
       

        public DbSet<Customer> Customers { get; set; }
        
        

      

    }



}
