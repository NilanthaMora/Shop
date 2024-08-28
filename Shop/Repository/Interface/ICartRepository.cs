using Shop.Models;

namespace Shop.Repository.Interface
{
    public interface ICartRepository  
    {
        Task<IEnumerable<ShoppingCart>> GetShoppingCarts();
        Task<ShoppingCart?> GetShoppingCartByID(string ID);
        Task<ShoppingCart> InsertShoppingCart(ShoppingCart obj);
        Task<ShoppingCart> UpdateShoppingCart(ShoppingCart obj);
        Task<bool> DeleteShoppingCart(string ID);   
    }
}
