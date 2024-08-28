using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Repository.Class
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly EshopContext _context;
        public SupplierRepository(EshopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ShopSupplier>> GetSupplieres()  
        {
            return await _context.ShopSuppliers.ToListAsync();
        }
        public async Task<ShopSupplier?> GetSupplierByID(int ID)
        {
            return await _context.ShopSuppliers.Where(a => a.SupplierId == ID).FirstOrDefaultAsync();
        }
        public async Task<ShopSupplier> InsertSupplier(ShopSupplier obj)
        {
            _context.ShopSuppliers.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<ShopSupplier> UpdateSupplier(ShopSupplier obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> DeleteSupplier(int ID)
        {
            bool result = false;
            var department = await _context.ShopSuppliers.Where(a => a.SupplierId == ID).FirstOrDefaultAsync();
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
