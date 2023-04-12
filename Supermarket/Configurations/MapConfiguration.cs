using AutoMapper;
using Supermarket.Dto.Models;
using Supermarket.Dto.Request;
using Supermarket.Dto.Response;

namespace Supermarket.Configurations
{
    public class MapConfiguration:Profile
    {
        public MapConfiguration()
        {
            CreateMap<Customer,CustomerRequest>().ReverseMap();
            CreateMap<Customer,CustomerResponse>().ReverseMap();
            CreateMap<CustomerRequest,CustomerResponse>().ReverseMap();
        }
    }
}
