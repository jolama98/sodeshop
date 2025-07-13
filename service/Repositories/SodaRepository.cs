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
}