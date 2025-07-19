namespace sodeshop.Models;

public class Cart : RepoItem<int>
{
  public int UserId { get; set; }
  public bool IsCheckedOut { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}