using MongoDB.Driver;
using WatchApiBackend.Models;
using Microsoft.Extensions.Options;

namespace WatchApiBackend.Services
{
  public class TeamService
  {
    private readonly IMongoCollection<Team> _team;

    public TeamService(IMongoDatabase db, IOptions<DatabaseSettings> settings)
    {
      _team = db.GetCollection<Team>(settings.Value.Collections.Team);
    }

    public async Task<bool> CreateUser(Team team)
    {
      var user = await _team.Find(item => item.Email == team.Email).FirstOrDefaultAsync();
      if (user != null)
        throw new Exception("User already exists");

      var _url = new URL
      {
        Url = team.URL
      };

      await _team.InsertOneAsync(team);
      return true;
    }

    public async Task LoginUser(string email, string password)
    {
      var user = await _team.Find(item => item.Email == email).FirstOrDefaultAsync();
      if (user == null)
        throw new Exception("User not found");
      if (user.Password != password)
        throw new Exception("Incorrect Password");
    }
  }
}
