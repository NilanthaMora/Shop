using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Repository.Class
{
    public class StoreRepository : IStoreRepository
    {
        private readonly EshopContext _context;
        public StoreRepository(EshopContext context)
        {
            _context = context; 
        } 
        public async Task<IEnumerable<Store>> GetStores()
        {
            return await _context.Stores.ToListAsync();
        }
        public async Task<Store?> GetStoreByID(int ID) 
        {
            return await _context.Stores.Where(a => a.StoreId == ID).FirstOrDefaultAsync();
        }
        public async Task<Store> InsertStore(Store objStore)
        {
            _context.Stores.Add(objStore);
            await _context.SaveChangesAsync();
            return objStore;
        }
        public async Task<Store> UpdateStore(Store objStore)
        {
            _context.Entry(objStore).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return objStore;
        }
        public async Task<bool> DeleteStore(int ID)
        {
            bool result = false;
            var department = await _context.Stores.Where(a => a.StoreId == ID).FirstOrDefaultAsync();
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
