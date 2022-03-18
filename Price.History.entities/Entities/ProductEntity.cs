using MongoDB.Bson.Serialization.Attributes;

namespace ;

public class ProductEntity
{
    [BsonElement("_id")]
    public string Name { get; set; } = null!;
    public string EANcode { get; set; } = null!;

}

public class ProductStateEntity
{
    public string Id { get; set; }
    public int Price { get; set; }
    public string ExpireDate { get; set; } = null!;
}