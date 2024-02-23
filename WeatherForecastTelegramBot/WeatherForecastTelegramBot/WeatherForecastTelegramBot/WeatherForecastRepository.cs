namespace WeatherForecastTelegramBot;

public class WeatherForecastRepository
{
    public static async Task<string> GetWeatherForecast(string city)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string apiKey = "d47551025b4245418bc183644242002";
                string apiUrl = $"http://api.weatherapi.com/v1/current.json?key=d47551025b4245418bc183644242002&q={city}&aqi=no\n";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return json;
                }
                else
                {
                    return response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
        
    