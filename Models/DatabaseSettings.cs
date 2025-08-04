namespace Watch_Api_Backend.Models;

public class DatabaseSettings
{
  public string ConnectionString { get; set; } = null!;
  public string DatabaseName { get; set; } = null!;
  public Collection Collections { get; set; } = null!;
}

public class Collection
{
    public string Users { get; set; } = null!;
    public string MonitoredApis { get; set; } = null!;
    public string ApiLogs { get; set; } = null!;
    public string Notifications { get; set; } = null!;
}