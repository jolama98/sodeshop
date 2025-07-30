namespace sodeshop.Repositories;
public class CartItemRepository
{
    private readonly IDbConnection _db;

    public CartItemRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Cart_items AddToCart(Cart_items cartItemData)
    {
        throw new NotImplementedException();
    }

    // Add methods for cart operations here
}
