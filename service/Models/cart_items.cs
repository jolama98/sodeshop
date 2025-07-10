namespace sodeshop.Models;

public class Cart_items : RepoItem<int>
{

  public int SodaId { get; set; }
  public int CartId { get; set; }
  public int Quantity { get; set; }
  public string Profile { get; set; }
}



