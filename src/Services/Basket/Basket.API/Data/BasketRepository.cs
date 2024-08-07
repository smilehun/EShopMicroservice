

namespace Basket.API.Data
{
    public class BasketRepository(IDocumentSession sesstion) : IBasketRepository
    {
       
        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await sesstion.LoadAsync<ShoppingCart>(userName, cancellationToken);
            return basket is null ? throw new BasketNotFoundException(userName) : basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            sesstion.Store(basket);
            await sesstion.SaveChangesAsync(cancellationToken);  
            return basket;
        }
        public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            sesstion.Delete<ShoppingCart>(userName);
            await sesstion.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
