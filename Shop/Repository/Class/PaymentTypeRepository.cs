using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Repository.Class
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly EshopContext _context;
        public PaymentTypeRepository(EshopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PaymentType>> GetPaymentTypes()
        {
            return await _context.PaymentTypes.ToListAsync();
        }
        public async Task<PaymentType?> GetPaymentTypeByID(int ID)
        {
            return await _context.PaymentTypes.Where(a => a.PaymentTypeId == ID).FirstOrDefaultAsync();
        }
        public async Task<PaymentType> InsertPaymentType(PaymentType obj)
        {
            _context.PaymentTypes.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<PaymentType> UpdatePaymentType(PaymentType obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> DeletePaymentType(int ID)
        {
            bool result = false;
            var department = await _context.PaymentTypes.Where(a => a.PaymentTypeId == ID).FirstOrDefaultAsync();
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
