
namespace sodeshop.Services;

public class CartService
{
    private readonly CartRepository _cartRepository;

    public CartService(CartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    internal Cart GetCartByUserId(string creatorId)
    {
        Cart cart = GetCartById(cartId);
    }
    

    private Cart GetCartById(string cartId)
    {
        Cart cart = _cartRepository.GetCartById(cartId) ?? throw new Exception("Cart not found."); 
        return cart;
    }
}