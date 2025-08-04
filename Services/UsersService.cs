using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Watch_Api_Backend.Models;






namespace Watch_Api_Backend.Services
{
    public class UsersService
    {
        private readonly IMongoCollection<User> _collection;
        public UsersService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var databaseName = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = databaseName.GetCollection<User>(databaseSettings.Value.Collections.Users);
        }

        public async Task<List<User>> GetUsersAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<User> GetUserAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateUserAsync(User newUser) =>
            await _collection.InsertOneAsync(newUser);
    }
}
