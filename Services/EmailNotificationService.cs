using MongoDB.Driver;
using WatchApiBackend.Models;
using Microsoft.Extensions.Options;

namespace WatchApiBackend.Services
{
  public class EmailNotificationService
  {
    private readonly IMongoCollection<EmailNotification> _emailNotification;

    public EmailNotificationService(IMongoDatabase db, IOptions<DatabaseSettings> settings)
    {
      _emailNotification = db.GetCollection<EmailNotification>(settings.Value.Collections.EmailNotification);
    }

    public async Task<EmailNotification> AddEmailNotification(EmailNotification emailNotification)
    {
      await _emailNotification.InsertOneAsync(emailNotification);
      return emailNotification;
    }
  }
}