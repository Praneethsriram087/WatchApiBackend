using Microsoft.AspNetCore.Mvc;
using WatchApiBackend.Models;
using WatchApiBackend.Services;

namespace WatchApiBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class ResponseLogController : ControllerBase
  {
    private readonly ResponseLogService _responseLogService;

    public ResponseLogController(ResponseLogService responseLogService)
    {
      _responseLogService = responseLogService;
    }

    [HttpPost]
    public async Task<ActionResult> UrlResponseLog(URL url)
    {
      try
      {
        var result = await _responseLogService.UrlResponse(url.Url);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
}
