using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using Tennis.Databases.Mongo.Entities;
using Tennis.Databases.Mongo.Repositories;
using Xunit;

public class PriceHistoryTest : ServiceProviderStartupBase, IClassFixture<MongoStartup>
{
    public PriceHistoryTest(MongoStartup mongoStartup)
    {
        string mongo = nameof(mongo);
        string latest= nameof(latest);

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((builder, services) =>
            {
                services.AddSingleton<IMongoClient>(c =>
                {
                    return new MongoClient($"mongodb://localhost:27017/?readPreference=primary&appname=MyTests&ssl=false");
                });

                services.AddScoped<MongoClientName>();
            })
            .Build();

        Services = host.Services;
    }

    [Fact]
    public async Task Price_Read()
    {
 
    }

    [Fact]
    public async Task Price_Insert()
    {

    }
}