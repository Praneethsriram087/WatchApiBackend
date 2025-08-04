using MongoDB.Driver;
using Watch_Api_Backend.Models;
using Microsoft.Extensions.Options;

namespace Watch_Api_Backend.services;

public class MonitoredApisService
{
    private readonly IMongoCollection<MonitoredApi> _collection;

    public MonitoredApisService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var databaseName = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _collection=databaseName.GetCollection<MonitoredApi>(databaseSettings.Value.Collections.MonitoredApis);
    }

    public async Task<List<MonitoredApi>> GetMonitoredApisAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<MonitoredApi> GetMonitoredApiAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateMonitoredApiAsync(MonitoredApi newMonitoredApi) =>
        await _collection.InsertOneAsync(newMonitoredApi);
}


