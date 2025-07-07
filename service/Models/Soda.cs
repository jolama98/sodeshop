namespace sodeshop.Models;

public class Soda : RepoItem<int>
{

  public string Name { get; set; }
  public string Description { get; set; }
  public string ImageUrl { get; set; }
  public decimal Price { get; set; }
  public string Category { get; set; }
  public int Stock { get; set; }
  public Profile Creator { get; set; }
}
