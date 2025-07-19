namespace sodeshop.Repositories;
public class CartItemRepository
{
    private readonly IDbConnection _db;

    public CartItemRepository(IDbConnection db)
    {
        _db = db;
    }

    // Add methods for cart operations here
}
