using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Repository.Class
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly EshopContext _context;
        public PaymentRepository(EshopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }
        public async Task<Payment?> GetPaymentByID(string ID)
        {
            return await _context.Payments.Where(a => a.PaymentId == ID).FirstOrDefaultAsync();
        }
        public async Task<Payment> InsertPayment(Payment obj)
        {
            _context.Payments.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<Payment> UpdatePayment(Payment obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> DeletePayment(string ID)
        {
            bool result = false;
            var department = await _context.Payments.Where(a => a.PaymentId == ID).FirstOrDefaultAsync();
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
