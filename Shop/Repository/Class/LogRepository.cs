using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Repository.Class
{
    public class LogRepository : ILogRepository
    {
        private readonly EshopContext _context;
        public LogRepository(EshopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ShopLog>> GetShopLogs()
        {
            return await _context.ShopLogs.ToListAsync();
        }
        public async Task<ShopLog?> GetShopLogByID(string ID)
        {
            return await _context.ShopLogs.Where(a => a.LogId == ID).FirstOrDefaultAsync();
        }
        public async Task<ShopLog> InsertShopLog(ShopLog obj)
        {
            _context.ShopLogs.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        
    }
}
