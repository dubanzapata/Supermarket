    using AutoMapper;
using Supermarket.Contrats.Interfaces.IRepositories;
using Supermarket.Contrats.Interfaces.Services;
using Supermarket.Dto.Request;
using Supermarket.Dto.Response;
using Supermarket.Dto.Models;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _Mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _Mapper = mapper;
        }
    
        public async Task<CustomerResponse> AddCustomer(CustomerRequest customer)
        {
            var Customer = _Mapper.Map<Customer>(customer);
            await _customerRepository.Add(Customer);
            return _Mapper.Map<CustomerResponse>(Customer);

        }

        public async Task<CustomerResponse> DeleteCustomer(int IdCustomer)
        {
            var customer = await _customerRepository.FindBy(x=>x.Pk_Customer==IdCustomer).FirstOrDefaultAsync();
            await _customerRepository.Delete(customer!);
            return _Mapper.Map<CustomerResponse>(customer);
        }

        public async Task<CustomerResponse> GetCustomerById(int IdCustomer)
        {
            var customer = await _customerRepository.FindBy(x => x.Pk_Customer == IdCustomer).FirstOrDefaultAsync();
            return _Mapper.Map<CustomerResponse>(customer);
        }

        public async Task<IEnumerable<CustomerResponse>> GetCustomers()
        {
            var customer= await _customerRepository.GetAll().ToListAsync();
            
            return _Mapper.Map<IEnumerable<CustomerResponse>>(customer);
        }

        public async Task<CustomerResponse> UpdateCustomer(int IdCustomer, CustomerRequest Customer)
        {
            var customerId = await _customerRepository.FindBy(x => x.Pk_Customer == IdCustomer).FirstOrDefaultAsync();
            _Mapper.Map(customerId,Customer);
            await _customerRepository.Update(customerId!);
            return _Mapper.Map<CustomerResponse>(customerId);
        }
    }
}
