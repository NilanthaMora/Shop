using Shop.Models;

namespace Shop.Repository.Interface
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<ShopSupplier>> GetSupplieres();
        Task<ShopSupplier?> GetSupplierByID(int ID);
        Task<ShopSupplier> InsertSupplier(ShopSupplier obj); 
        Task<ShopSupplier> UpdateSupplier(ShopSupplier obj);
        Task<bool> DeleteSupplier(int ID);
    }
}
