namespace sodeshop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SodaController : ControllerBase
{
  private readonly SodaService _sodaService;
  private readonly Auth0Provider _auth0Provider;

  public SodaController(SodaService sodaService, Auth0Provider auth0Provider)
  {
    _sodaService = sodaService;
    _auth0Provider = auth0Provider;
  }


  [HttpGet]
  public ActionResult<List<Soda>> GetAllSodas()
  {
    try
    {
      List<Soda> soda = _sodaService.GetAllSodas();
      return Ok(soda);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
