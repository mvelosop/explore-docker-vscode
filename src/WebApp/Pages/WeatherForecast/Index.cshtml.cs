using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebApp.Pages.WeatherForecast
{
  public class IndexModel : PageModel
  {
    private const string ApiGetUrl = "WeatherForecast";
    private readonly ILogger<IndexModel> _logger;
    private readonly WeatherForecastApiClient client;

    public IndexModel(
        ILogger<IndexModel> logger,
        WeatherForecastApiClient client)
    {
      _logger = logger;
      this.client = client;
    }

    public string GetApiUrl => client.GetApiUri(ApiGetUrl);

    public List<WeatherForecast> Items { get; set; }

    public string ErrorMessage { get; private set; }

    public async Task OnGet()
    {
      try
      {
        var response = await client.GetAsync(ApiGetUrl);
        var content = await response.Content.ReadAsStringAsync();
        Items = JsonConvert.DeserializeObject<List<WeatherForecast>>(content);
      }
      catch (Exception ex)
      {
        ErrorMessage = ex.Message;
      }
    }

  }
}
