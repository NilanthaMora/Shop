using Shop.Models;

namespace Shop.Repository.Interface
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetProductTypes();
        Task<ProductType?> GetProductTypeByID(int ID);
        Task<ProductType> InsertProductType(ProductType obj);
        Task<ProductType> UpdateProductType(ProductType obj);
        Task<bool> DeleteProductType(int ID); 
    }
}
