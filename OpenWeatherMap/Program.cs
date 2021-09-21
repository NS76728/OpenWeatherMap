using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace OpenWeatherMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
          
            Console.WriteLine("Enter your API");
            var key = Console.ReadLine();
            bool stopper = true;
            while (stopper)
            {
                Console.WriteLine();
                Console.WriteLine("Enter city name (Enter stop to exit)");
                string city = Console.ReadLine();
                if (city == "stop")
                {
                    stopper = false;
                }
                else
                {
                    var weatherUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={key}";
                    var response = client.GetStringAsync(weatherUrl).Result;
                    var formatresponse = JObject.Parse(response).GetValue("main").ToString();
                    Console.WriteLine(formatresponse);
                    Console.WriteLine();
                }
            }
        }
    }
}
