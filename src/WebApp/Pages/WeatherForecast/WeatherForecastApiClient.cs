using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Pages.WeatherForecast
{
  public class WeatherForecastApiClient
  {
    private readonly HttpClient client;

    public WeatherForecastApiClient(HttpClient client)
    {
      this.client = client;
    }

    public string GetApiUri(string url) => $"{client.BaseAddress}{url}";

    public async Task<HttpResponseMessage> GetAsync(string url)
    {
      return await client.GetAsync(url);
    }
  }
}