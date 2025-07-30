

namespace sodeshop.Repositories;

public class CartRepository
{
    private readonly IDbConnection _db;

    public CartRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Cart CreateCart(Cart cartData)
    {
        string sql = @"
        INSERT INTO carts (cartData)
        VALUES (@cartData);
        SELECT * FROM carts WHERE id = LAST_INSERT_ID();";

        return _db.QueryFirstOrDefault<Cart>(sql, new { cartData });
    }


//     public Cart CreateCart(int userId)
// {
//     string sql = @"
//     INSERT INTO carts (userId)
//     VALUES (@userId);
//     SELECT * FROM carts WHERE id = LAST_INSERT_ID();";

//     return _db.QueryFirstOrDefault<Cart>(sql, new { userId });
// }

    internal Cart GetCartById(int cartId)
    {
        string sql = @"
        SELECT 
        carts.*,
        accounts.*
        FROM carts
        JOIN account ON carts.creatorId = account.id
        WHERE carts.id = @cartsId
        ;";

        Cart cart = _db.Query<Cart, Profile, Cart>(sql, JoinCreator, new
        {
            cartId
        }).FirstOrDefault();
        return cart;
    }

    private Cart JoinCreator(Cart cart, Profile profile)
    {
        cart.Creator = profile;
        return cart;
    }

}
