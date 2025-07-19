
namespace sodeshop.Repositories;

public class CartRepository
{
    private readonly IDbConnection _db;

    public CartRepository(IDbConnection db)
    {
        _db = db;
    }

    internal object GetCartById(string cartId)
    {
        throw new NotImplementedException();
    }

    // Add methods for cart operations here
}
