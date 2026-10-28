using System;
class Program
{
    static void Main()
    {
        WeatherService Service1 = new WeatherService();
        var DataWeather = Service1.GetWeather();

        WeatherPrinter.ShowInfo(DataWeather);
    }
}
class WeatherService
{
    private string _lastResponse = "Warsaw;12";
    public WeatherInfo GetWeather()
    {
        string[] parts = _lastResponse.Split(';');
        return new WeatherInfo { City = parts[0], Temperature = int.Parse(parts[1]) };
    }

}
class WeatherInfo
{
    public string City { get; set; } = "";
    public int Temperature { get; set; } = 0;
}
static class WeatherPrinter
{
    public static void ShowInfo(WeatherInfo info)
    {
        Console.WriteLine($"City - {info.City} and Temperature +{info.Temperature}");
    }

}

