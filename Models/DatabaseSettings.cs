namespace WatchApiBackend.Models
{
  public class DatabaseSettings
  {
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public Collections Collections { get; set; } = null!;
  }

  public class Collections
  {
    public string Team { get; set; } = null!;
    public string ResponseLog { get; set; } = null!;
    public string EmailNotification { get; set; } = null!;
  }
}