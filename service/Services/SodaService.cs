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
}
