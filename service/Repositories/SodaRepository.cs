
namespace sodeshop.Repositories;

public class SodaRepository
{
  private readonly IDbConnection _db;

  public SodaRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Soda> GetAllSodas()
  {
    string sql = @"
    SELECT 
  sodas.,
  COUNT(cart_items.id) AS times_in_cart,
  accounts.*
FROM sodas
JOIN accounts ON accounts.id = sodas.creatorId
LEFT JOIN cart_items ON cart_items.soda_id = sodas.id
GROUP BY sodas.id, sodas.name;3";

    List<Soda> sodas = _db.Query<Soda, Profile, Soda>(sql, (soda, profile) =>
    {
      soda.Creator = profile;
      return soda;
    }).ToList();
    return sodas;

  }
  
    // internal List<Keep> GetAllKeeps()
    // {
    //     string sql = @"
    // SELECT
    // keeps.*,
    // COUNT(vaultKeep.id) AS Kept,
    // accounts.*
    // FROM keeps
    // JOIN accounts ON accounts.id = keeps.creatorId
    // LEFT JOIN vaultKeep ON vaultKeep.keepId = keeps.id
    // GROUP BY (keeps.id)
    // ;";

    //     List<Keep> keep = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    //     {
    //         keep.Creator = profile;
    //         return keep;
    //     }).ToList();

    //     return keep;
    // }


    private Soda JoinCreator(Soda Soda, Profile profile)
  {
    Soda.Creator = profile;
    return Soda;
  }
}