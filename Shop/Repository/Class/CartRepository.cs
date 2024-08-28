using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Repository.Class
{
    public class CartRepository : ICartRepository
    {
        private readonly EshopContext _context;
        public CartRepository(EshopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ShoppingCart>> GetShoppingCarts()
        {
            return await _context.ShoppingCarts.ToListAsync();
        }
        public async Task<ShoppingCart?> GetShoppingCartByID(string ID)
        {
            return await _context.ShoppingCarts.Where(a => a.CartId == ID).FirstOrDefaultAsync();
        }
        public async Task<ShoppingCart> InsertShoppingCart(ShoppingCart obj)
        {
            _context.ShoppingCarts.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<ShoppingCart> UpdateShoppingCart(ShoppingCart obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> DeleteShoppingCart(string ID)
        {
            bool result = false;
            var department = await _context.ShoppingCarts.Where(a => a.CartId == ID).FirstOrDefaultAsync();
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
