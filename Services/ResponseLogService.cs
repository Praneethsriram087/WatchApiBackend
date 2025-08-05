using MongoDB.Driver;
using WatchApiBackend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using System.Diagnostics;

namespace WatchApiBackend.Services
{
  public class ResponseLogService
  {
    private readonly IMongoCollection<ResponseLog> _responseLog;

    public ResponseLogService(IMongoDatabase db, IOptions<DatabaseSettings> settings)
    {
      _responseLog = db.GetCollection<ResponseLog>(settings.Value.Collections.ResponseLog);
    }

    public async Task<ResponseLog> UrlResponse(string url)
    {
      var client = new HttpClient();
      var curretTime = DateTime.UtcNow;
      int statuscode = 0;
      long responseTime = 0;
      bool success = false;
      string? errorMessage = null;
      var stopwatch = new Stopwatch();

      try
      {
        stopwatch.Start();
        var res = await client.GetAsync(url);
        stopwatch.Stop();

        statuscode = (int)res.StatusCode;

        responseTime = stopwatch.ElapsedMilliseconds;
        success = res.IsSuccessStatusCode;

        if (!success)
        {
          errorMessage = $"Http error {res.StatusCode}, {res.ReasonPhrase}";
        }

      }
      catch (Exception ex)
      {
        stopwatch.Stop();
        responseTime = stopwatch.ElapsedMilliseconds;
        errorMessage = ex.Message;
        success = false;
      }
      var _responseLogEntry = new ResponseLog
      {
        Url = url,
        TimeStamp = curretTime,
        StatusCode = statuscode,
        ResponseTime = responseTime,
        Success = success,
        ErrorMessage  = errorMessage
      };

      return await AddResponseLog(_responseLogEntry);
    }
    public async Task<ResponseLog> AddResponseLog(ResponseLog responseLog)
    {
      await _responseLog.InsertOneAsync(responseLog);
      return responseLog;
    }
  }
}