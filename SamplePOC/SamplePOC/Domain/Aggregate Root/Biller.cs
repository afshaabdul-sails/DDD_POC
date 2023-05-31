using SamplePOC.Domain.Entities;

namespace SamplePOC.Domain.Aggregates
{
    public class Biller
    {
        //Aggregate
        public int? BillerId { get; set; }
        public string BillerName { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public Biller()
        {
            Customers = new List<Customer>();
        }
    }
}
