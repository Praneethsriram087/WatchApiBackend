using MongoDB.Driver;
using Watch_Api_Backend.Models;
using Microsoft.Extensions.Options;

namespace Watch_Api_Backend.Services;

public class ConnectionService
{
  private readonly IMongoCollection<User> _users;
  private readonly IMongoCollection<MonitoredApi> _monitoredApis;
  private readonly IMongoCollection<ApiLog> _apiLogs;
  private readonly IMongoCollection<EmailNotification> _emailNotification;

  public ConnectionService(IMongoDatabase database, IOptions<DatabaseSettings> dbSettings)
  {
    var collections = dbSettings.Value.Collections;

    _users = database.GetCollection<User>(collections.Users);
    _monitoredApis = database.GetCollection<MonitoredApi>(collections.MonitoredApis);
    _apiLogs = database.GetCollection<ApiLog>(collections.ApiLogs);
    _emailNotification = database.GetCollection<EmailNotification>(collections.Notifications);
  }

  

  public async Task ConnectMonitoredApiIdWithUserId(string userEmail, string url, int interval)
  {
    var user = await _users.Find(item => item.Email == userEmail).FirstOrDefaultAsync();
    if (user.Id == null)
    {
      throw new Exception("User Id is null");
    }
    var monitoredApis = new MonitoredApi
    {
      UserId = user.Id,
      Url = url,
      Interval = interval
    };

    await _monitoredApis.InsertOneAsync(monitoredApis);
  }

  public async Task ConnectApiLogsWithMoniterApiIdAndAddInDb(MonitoredApi monitoredApi, string statusCode, double responseTime, string errorMessage)
  {
    var apiExists = await _monitoredApis.Find(item => item.Id == moniteredApi.Id).AnyAsync();
    if (!apiExists)
    {
      throw new Exception("Api not found");
    }
    var log = new ApiLog
    {
      MonitoredApi = MoniteredApi,
      TimeStamp = DateTime.UtcNow,
      StatusCode = statusCode,
      ResponseTimeMs = responseTime,
      Success = true,
      ErrorMessage = errorMessage
    };
    await _apiLogs.InsertOneAsync(log);
  }

  public async Task ConnectEmailNotficationWithErrorMessage(string apiLogId, bool success)
  {
    var log = await _apiLogs.Find(log => log.Id == apiLogId).FirstOrDefaultAsync();
    if (log == null)
      throw new Exception("ApiLog not found");

    if (!success)
    {
      var notification = new EmailNotification
      {
        MonitoredApiId = log.MonitoredApi.Id,
        Timestamp = log.TimeStamp,
        StatusCode = log.StatusCode,
        ResponseTimeMs = log.ResponseTimeMs,
        Success = false,
        ErrorMessage = log.ErrorMessage,
        SentAt = DateTime.UtcNow
      };
      await _emailNotification.InsertOneAsync(notification);
    }
  }
}