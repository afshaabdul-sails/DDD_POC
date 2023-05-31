using System.Net;

namespace SamplePOC.Domain.Entities
{
    public class Customer
    {
        //Entity
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }

        // Value Object
        public List<Address>? Address { get; set; }
    }
        // Value Object
    public class Address
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? ZipCode { get; set; }
    }
}
