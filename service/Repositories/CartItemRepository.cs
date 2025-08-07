
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

    internal List<CartSodaSoda> GetCartSodasByCartId(int cartId, string userId)
    {
        string sql = @"
        SELECT
        cart_items.*,
        soda.*,
        account.*,
        FROM cart_items
        JOIN account ON account.id = cart_items.creatorId
        JOIN soda ON soda.id = cart_items.sodaId
        WHERE cart_items.cartId = @cartId;
        ;";

        List<CartSodaSoda> cartSodaSodas = _db.Query<Cart_items, CartSodaSoda, Profile, CartSodaSoda>(
            sql,
            (cartItems, soda, profile) =>
            {
                soda.AccountId = cartItems.CreatorId;
                soda.Cart_itemsId = cartItems.Id;
                soda.Creator = profile;
                return soda;
            },
            new { cartId, userId }
        ).ToList();
        return cartSodaSodas;

    }
}
