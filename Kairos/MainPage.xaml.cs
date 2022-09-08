using System;
using Xamarin.Forms;

namespace Kairos
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;
        private static string lastCity;
        private static bool flag = false;
        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }
        async void OnGoButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                lastCity = _cityEntry.Text;
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Key.APILink),flag);
                BindingContext = weatherData;
            }
            else 
                {
                    await DisplayAlert("Error", "Please enter the city name", "OK");
                }
        }
        string GenerateRequestUri(string endpoint)
        {
            if (!flag)
            {
                string requestUri = endpoint;
                requestUri += $"?q={_cityEntry.Text}";
                requestUri += "&units=metric";
                requestUri += $"&APPID={Key.APIKey}";
                return requestUri;
            }
            else 
            {
                string requestUri = endpoint;
                requestUri += $"?q={lastCity}";
                requestUri += "&units=metric";
                requestUri += $"&APPID={Key.APIKey}";
                
                return requestUri;
            }
        }

        async void OnRefButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lastCity))
            {
                flag = true;
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Key.APILink),flag);
                BindingContext = weatherData;
                flag = false;
            }
            else
            {
                await DisplayAlert("Error", "Nothing to refresh!", "OK");
            }

        }
    }
    

}
