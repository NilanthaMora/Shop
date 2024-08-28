using Shop.Models;

namespace Shop.Repository.Interface
{
    public interface IProductRepository  
    {
        Task<IEnumerable<ShopProduct>> GetShopProducts();
        Task<ShopProduct?> GetShopProductByID(string ID);
        Task<ShopProduct> InsertShopProduct(ShopProduct obj);
        Task<ShopProduct> UpdateShopProduct(ShopProduct obj);
        Task<bool> DeleteShopProduct(string ID);  
    }
}
