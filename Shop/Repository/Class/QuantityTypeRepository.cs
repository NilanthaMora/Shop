using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Repository.Class
{
    public class QuantityTypeRepository : IQuantityTypeRepository
    {
        private readonly EshopContext _context;
        public QuantityTypeRepository(EshopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QuantityType>> GetQuantityTypes()
        {
            return await _context.QuantityTypes.ToListAsync();
        }
        public async Task<QuantityType?> GetQuantityTypeByID(int ID)
        {
            return await _context.QuantityTypes.Where(a => a.QuantityTypeId == ID).FirstOrDefaultAsync();
        }
        public async Task<QuantityType> InsertQuantityType(QuantityType obj)
        {
            _context.QuantityTypes.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<QuantityType> UpdateQuantityType(QuantityType obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> DeleteQuantityType(int ID) 
        {
            bool result = false;
            var department = await _context.QuantityTypes.Where(a => a.QuantityTypeId == ID).FirstOrDefaultAsync();
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
