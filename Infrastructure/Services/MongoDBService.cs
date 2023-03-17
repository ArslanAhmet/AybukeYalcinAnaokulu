using AybukeYalcinAnaokulu.Core.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AybukeYalcinAnaokulu.Infrastructure.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<EmergencyApplicationForm> _applicationFormCollection;
        public MongoDBService(IOptions<MongoDbSettings> options)
        {
            MongoClient mongoClient = new MongoClient(options.Value.ConnectionUri);
            IMongoDatabase database = mongoClient.GetDatabase(options.Value.DatabaseName);
            _applicationFormCollection = database.GetCollection<EmergencyApplicationForm>(options.Value.CollectionName);
        }

        public async Task CreateAsync(EmergencyApplicationForm applicationForm)
        {
            await _applicationFormCollection.InsertOneAsync(applicationForm);

            return;
        }


        public async Task<List<EmergencyApplicationForm>> GetAsync()
        {
            return await _applicationFormCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<EmergencyApplicationForm> filter = Builders<EmergencyApplicationForm>.Filter.Eq("Id", id);
            await _applicationFormCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
