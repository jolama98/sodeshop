namespace sodeshop.Models;

public class Cart : RepoItem<int>
{
  public string CreatorId { get; set; }
  public int UserId { get; set; }
  public bool IsCheckedOut { get; set; }
  public Profile Creator { get; set; }
}