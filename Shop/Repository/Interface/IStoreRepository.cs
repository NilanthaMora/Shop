using Shop.Models;

namespace Shop.Repository.Interface
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetStores();
        Task<Store?> GetStoreByID(int ID);
        Task<Store> InsertStore(Store objStore);
        Task<Store> UpdateStore(Store objStore);
        Task<bool> DeleteStore(int ID);
    }
}
