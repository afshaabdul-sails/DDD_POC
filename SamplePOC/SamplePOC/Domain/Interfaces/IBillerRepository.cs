using SamplePOC.Domain.Aggregates;
using SamplePOC.Domain.Entities;

namespace SamplePOC.Domain.Interfaces
{
    public interface IBillerRepository
    {
        Task<Biller> GetBillerById(int id);
        Task<int> AddBiller(Biller biller);
        Task<int> UpdateBiller(Biller biller);
        Task<int> RemoveBiller(Task<Biller> biller);
    }
}
