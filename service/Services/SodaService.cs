
namespace sodeshop.Services;

public class SodaService
{
    private readonly SodaRepository _repo;

    public SodaService(SodaRepository repo)
    {
        _repo = repo;
    }

    internal List<Soda> GetAllSodas()
    {
        List<Soda> sodas = _repo.GetAllSodas();
        return sodas;
           }
}
