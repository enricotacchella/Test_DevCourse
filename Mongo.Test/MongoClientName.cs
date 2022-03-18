using System;

namespace Mongo.Test
{
    public class MongoClientName
    {
        public string DatabaseName { get; set; } = "Test_PriceHistory_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
    }
}