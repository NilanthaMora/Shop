using Shop.Models;

namespace Shop.Repository.Interface
{
    public interface ILogRepository   
    {
        Task<IEnumerable<ShopLog>> GetShopLogs();
        Task<ShopLog?> GetShopLogByID(string ID);
        Task<ShopLog> InsertShopLog(ShopLog obj);   
    }
}
