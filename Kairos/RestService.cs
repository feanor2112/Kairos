using Android.Widget;
using Newtonsoft.Json;
using Plugin.SimpleAudioPlayer;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kairos
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherData(string query, bool flag)
        {
            WeatherData weatherData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                    if (flag)
                    {
                        var player = CrossSimpleAudioPlayer.Current;
                        player.Load("Success.wav");
                        player.Play();
                    }
                }
                else
                {
                    Toast.MakeText(Android.App.Application.Context, "Failed to Load info. Please, check your input.", ToastLength.Short).Show();
                    var player = CrossSimpleAudioPlayer.Current;
                    player.Load("Fail.mp3");
                    player.Play();
                }
            
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return weatherData;
        }
    }
}
