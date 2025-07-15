
namespace sodeshop.Repositories;

public class SodaRepository
{
    private readonly IDbConnection _db;

    public SodaRepository(IDbConnection db)
    {
        _db = db;
    }

    // // If you want to return all sodas, change the return type to List<Soda>
    internal List<Soda> GetAllSodas()
    {
        string sql = @"
SELECT
sodas.*,
accounts.*
FROM sodas
JOIN accounts ON accounts.id = sodas.creatorId;
;";

        List<Soda> sodas = _db.Query<Soda, Profile, Soda>(sql, (soda, profile) =>
                {
                    soda.Creator = profile;
                    return soda;
                }).ToList();
        return sodas;
    }

    internal Soda GetSodaById(int sodaId)
    {
        string sql = @"
        SELECT
sodas.*,
accounts.*
FROM sodas
JOIN accounts ON accounts.id = sodas.creatorId
WHERE sodas.id = @sodaId
GROUP BY (sodas.id)
        ;";

        Soda soda = _db.Query<Soda, Profile, Soda>(sql, JoinCreator, new
        {
            sodaId

        }).FirstOrDefault();
return soda;
    }
    


    private Soda JoinCreator(Soda soda, Profile profile)
    {
        soda.Creator = profile;
        return soda;
    }
}