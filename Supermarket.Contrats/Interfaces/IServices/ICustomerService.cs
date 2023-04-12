using Supermarket.Dto.Request;
using Supermarket.Dto.Response;

namespace Supermarket.Contrats.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponse>> GetCustomers();
        Task<CustomerResponse> GetCustomerById(int IdCustomer);
        Task<CustomerResponse> AddCustomer(CustomerRequest  customer);
        Task<CustomerResponse> UpdateCustomer(int IdCustomer,CustomerRequest Customer);
        Task<CustomerResponse> DeleteCustomer(int IdCustomer);
    }
}
