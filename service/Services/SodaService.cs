
namespace sodeshop.Services;

public class SodaService
{
    private readonly SodaRepository _sodaRepository;
    public SodaService(SodaRepository sodaRepository)
    {
        _sodaRepository = sodaRepository;
    }

    internal List<Soda> GetAllSodas()
    {
        List<Soda> soda = _sodaRepository.GetAllSodas();
        return soda;
    }

    internal Soda GetSodaById(int sodaId)
    {
        Soda soda = _sodaRepository.GetSodaById(sodaId);
        if (soda == null)
        {
            throw new Exception("Soda not found");
        }
        return soda;
    }
}
