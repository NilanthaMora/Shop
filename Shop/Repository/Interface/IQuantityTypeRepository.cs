using Shop.Models;

namespace Shop.Repository.Interface
{
    public interface IQuantityTypeRepository
    {
        Task<IEnumerable<QuantityType>> GetQuantityTypes();
        Task<QuantityType?> GetQuantityTypeByID(int ID);
        Task<QuantityType> InsertQuantityType(QuantityType obj);
        Task<QuantityType> UpdateQuantityType(QuantityType obj);
        Task<bool> DeleteQuantityType(int ID); 
    }
}
