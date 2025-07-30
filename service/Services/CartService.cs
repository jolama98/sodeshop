
namespace sodeshop.Services;

public class CartService
{
    private readonly CartRepository _cartRepository;
 
    public CartService(CartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    internal Cart CreateCart(Cart cartData)
    {
        Cart cart = _cartRepository.CreateCart(cartData);
        return cart;
    }

    internal Cart GetCartByUserId(int cartId, string creatorId)
    {
    
        Cart cart = GetCartById(cartId);
        if (cart.IsCheckedOut == true && cart.CreatorId != creatorId)
        {
            throw new Exception("You cannot access a cart that has already been checked out by another user.");
        }
        return cart;

    }


    private Cart GetCartById(int cartId)
    {
        Cart cart = _cartRepository.GetCartById(cartId) ?? throw new Exception($"No cart found with that id of {cartId}"); 
        return cart;
    }
}