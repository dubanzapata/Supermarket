﻿namespace Supermarket.Dto.Response
{
    public  class CustomerResponse
    {
        public int Pk_Customer { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? NumberPhone { get; set; }
        public string? Mail { get; set; }
        public string? Address { get; set; }
    }
}
