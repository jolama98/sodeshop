namespace sodeshop.Models;

public class Cart_items : RepoItem<int>
{

  public int SodaId { get; set; }
  public int CartId { get; set; }
  public int Quantity { get; set; }
  public string CreatorId { get; set; }
}


public class CartSodaSoda : Soda
{
public int Cart_itemsId { get; set; }
public int CartId { get; set; }
public string Image { get; set; }
public string AccountId { get; set; }
}


