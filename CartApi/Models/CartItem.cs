public class CartItem
{

    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? ItemName { get; set; }


    public int Quantity { get; set; }
    public string? PhoneNumber { get; set; }

    public decimal UnitPrice { get; set; }



    public CartItem()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}
