using Shop.Models;

namespace Shop.Repository.Interface
{
    public interface IPaymentRepository  
    {
        Task<IEnumerable<Payment>> GetPayments();
        Task<Payment?> GetPaymentByID(string ID);
        Task<Payment> InsertPayment(Payment obj);
        Task<Payment> UpdatePayment(Payment obj);
        Task<bool> DeletePayment(string ID);    
    }
}
