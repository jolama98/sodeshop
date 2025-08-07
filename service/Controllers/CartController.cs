namespace sodeshop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;
    private readonly CartItemService _cartItemService;
    private readonly Auth0Provider _auth0Provider;

    public CartController(Auth0Provider auth0Provider, CartItemService cartItemService, CartService cartService)
    {
        _auth0Provider = auth0Provider;
        _cartItemService = cartItemService;
        _cartService = cartService;
    }
    // SECTION - Create a new cart
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Cart>> CreateCart([FromBody] Cart cartData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

            cartData.CreatorId = userInfo.Id;
            Cart cart = _cartService.CreateCart(cartData);
            return Ok(cart);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }


    // SECTION - Get cart by soda ID
    [HttpGet("{cardId}/sodas")]
    public async Task<ActionResult<List<CartSodaSoda>>> GetPublicCard(int cartId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            List<CartSodaSoda> cartSodas = _cartItemService.GetCartSodasByCartId(cartId, userInfo?.Id);
            return Ok(cartSodas);
    }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
}
    // Add methods for cart operations here
}
 