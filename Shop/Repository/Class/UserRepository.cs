using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Repository.Class
{
    public class UserRepository : IUserRepository
    {
        private readonly EshopContext _context;
        private readonly IConfiguration _config;
        public UserRepository(EshopContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task<IEnumerable<ShopUser>> GetShopUsers()
        {
            return await _context.ShopUsers.ToListAsync();
        }
        public async Task<ShopUser?> GetShopUserByID(string userName, string password)
        {
            List<ShopUser> user = await _context.ShopUsers.Where(a => a.UserName == userName).ToListAsync();
            return user.Where( a => (AesOperation.DecryptString(_config["Aes:Key"], a.UserPassword)) == password).FirstOrDefault();
        }
        public async Task<ShopUser> InsertShopUser(ShopUser obj)
        {
            _context.ShopUsers.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<ShopUser> UpdateShopUser(ShopUser obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> DeleteShopUser(string ID)
        {
            bool result = false;
            var department = await _context.ShopUsers.Where(a => a.UserId == ID).FirstOrDefaultAsync();
            if (department != null)
            {
                _context.Entry(department).State = EntityState.Deleted;
                _context.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
