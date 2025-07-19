namespace sodeshop.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CartItemController : ControllerBase
{
  private readonly CartItemService _cartItemService;
  private readonly Auth0Provider _auth0Provider;

  public CartItemController(CartItemService cartItemService, Auth0Provider auth0Provider)
  {
    _cartItemService = cartItemService;
    _auth0Provider = auth0Provider;
  }
  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Cart_items>> AddToCart([FromBody] Cart_items cartItem)
  {
    try
    {
     Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      cartItem.CreatorId = userInfo.Id;
      Cart_items cart_items = _cartItemService.AddToCart(cartItemData);
      return Ok(cart_items);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
    
}
