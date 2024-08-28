using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Repository.Class
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly EshopContext _context;
        public ProductTypeRepository(EshopContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }
        public async Task<ProductType?> GetProductTypeByID(int ID)
        {
            return await _context.ProductTypes.Where(a => a.ProductTypeId == ID).FirstOrDefaultAsync();
        }
        public async Task<ProductType> InsertProductType(ProductType obj)
        {
            _context.ProductTypes.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<ProductType> UpdateProductType(ProductType obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> DeleteProductType(int ID) 
        {
            bool result = false;
            var department = await _context.ProductTypes.Where(a => a.ProductTypeId == ID).FirstOrDefaultAsync();
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
