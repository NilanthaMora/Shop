using Shop.Models;

namespace Shop.Repository.Interface
{
    public interface IUserRepository  
    {
        Task<IEnumerable<ShopUser>> GetShopUsers();
        Task<ShopUser?> GetShopUserByID(string userName, string password);
        Task<ShopUser> InsertShopUser(ShopUser obj);
        Task<ShopUser> UpdateShopUser(ShopUser obj);
        Task<bool> DeleteShopUser(string ID);   
    }
}
