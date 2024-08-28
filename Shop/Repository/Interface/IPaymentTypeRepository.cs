using Shop.Models;

namespace Shop.Repository.Interface
{
    public interface IPaymentTypeRepository
    {
        Task<IEnumerable<PaymentType>> GetPaymentTypes();
        Task<PaymentType?> GetPaymentTypeByID(int ID);
        Task<PaymentType> InsertPaymentType(PaymentType obj);
        Task<PaymentType> UpdatePaymentType(PaymentType obj);
        Task<bool> DeletePaymentType(int ID); 
    }
}
