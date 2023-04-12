using Supermarket.Contrats.Interfaces.IRepositories;
using Supermarket.Dto.Models;

namespace Supermarket.Infraestrutura.Repositories
{
    public  class CustomerRepository:BaseRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(SupermarketDbContext context):base(context) 
        {

        }

    }
}

