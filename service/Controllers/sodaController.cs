namespace sodeshop.Controllers;


[ApiController]
[Route("[controller]")]
public class SodaController : ControllerBase
{
    private readonly SodaService _sodaService;
    private readonly Auth0Provider _auth0Provider;

    public SodaController(Auth0Provider auth0Provider, SodaService sodaService)
    {
        _auth0Provider = auth0Provider;
        _sodaService = sodaService;
    }


    [HttpGet]
    public ActionResult<List<Soda>> GetAllSodas()
    {
        try
        {
            List<Soda> sodas = _sodaService.GetAllSodas();
            return Ok(sodas);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    } 
}