
namespace sodeshop.Services;

public class CartItemService
{
    private readonly CartService _cartService;
    private readonly CartItemRepository _cartItemRepository;
    private readonly CartItemService _cartItemService;

    public CartItemService(CartItemRepository cartItemRepository, CartItemService cartItemService)
    {
        _cartItemRepository = cartItemRepository;
        _cartItemService = cartItemService;
    }

    internal Cart_items AddToCart(Cart_items cartItemData)
    {
Cart cart = _cartService.GetCartByUserId(cartItemData.CreatorId);
        if (cartItemData.CreatorId != cart.CreatorId)
        {
            throw new Exception("You cannot add items to another user's cart.");
        }
       

    }
}