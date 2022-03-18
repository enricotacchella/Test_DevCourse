namespace Test.price.entity;

public class PriceEntity
{
    public int Price { get; set; } = null!;
    public string StartDate { get; set; } = null!;
    public string StopDate { get; set; } = null!;

    public int Discount { get; set; };
}
