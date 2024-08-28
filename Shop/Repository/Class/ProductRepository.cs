using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Repository.Class
{
    public class ProductRepository : IProductRepository
    {
        private readonly EshopContext _context;
        public ProductRepository(EshopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ShopProduct>> GetShopProducts()
        {
            return await _context.ShopProducts.ToListAsync();
        }
        public async Task<ShopProduct?> GetShopProductByID(string ID)
        {
            return await _context.ShopProducts.Where(a => a.ProductId == ID).FirstOrDefaultAsync();
        }
        public async Task<ShopProduct> InsertShopProduct(ShopProduct obj)
        {
            _context.ShopProducts.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<ShopProduct> UpdateShopProduct(ShopProduct obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> DeleteShopProduct(string ID)
        {
            bool result = false;
            var department = await _context.ShopProducts.Where(a => a.ProductId == ID).FirstOrDefaultAsync();
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
