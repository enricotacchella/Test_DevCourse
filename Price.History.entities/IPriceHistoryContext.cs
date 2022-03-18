using MongoDB.Driver;


public interface IPriceHistoryContext
{
    public IMongoCollection<ProductEntity> Product { get; }
    public IMongoCollection<PriceEntity> Price { get; }

    public Task DeleteCollectionAsync();
}

IPriceHistoryContext