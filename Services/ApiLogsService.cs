using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Watch_Api_Backend.Models;






namespace ApiLogsServices.Services
{

namespace ApiLogsServices.Services
{
    public class ApiLogsService
    {
        private readonly IMongoCollection<ApiLog> _collection;
        public ApiLogsService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var databaseName = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = databaseName.GetCollection<ApiLog>(databaseSettings.Value.Collections.ApiLogs);
        }

        public async Task<List<ApiLog>> GetApiLogs() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<ApiLog> GetApiLog(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateApiLog(ApiLog newApiLog)=>
        await _collection.InsertOneAsync(newApiLog);
        
    }
}
}
