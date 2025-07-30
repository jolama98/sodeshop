namespace sodeshop.Services;

public class CartItemService
{
    private readonly CartItemRepository _cartItemRepository;
    private readonly CartService _cartService;
    private readonly SodaService _sodaService;

    public CartItemService(CartItemRepository cartItemRepository, CartService cartService, SodaService sodaService)
    {
        _cartItemRepository = cartItemRepository;
        _cartService = cartService;
        _sodaService = sodaService;
    }



    internal Cart_items AddToCart(Cart_items cartItemData)
    {
        Cart cart = _cartService.GetCartByUserId(cartItemData.CartId, cartItemData.CreatorId);
        
        if (cartItemData.CreatorId != cart.CreatorId)
        {
            throw new Exception("You cannot add items to another user's cart.");
        }
        Cart_items cart_Items = _cartItemRepository.AddToCart(cartItemData);
        return cart_Items;

    }
}