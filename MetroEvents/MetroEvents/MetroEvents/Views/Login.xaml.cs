using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MetroEvents.Models;
using MetroEvents.Views;

using Newtonsoft.Json;
using System.Net.Http;

namespace MetroEvents.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        /*public async void LoginOnApp(object sender, EventArgs e)
        {
            var jsonObject = new User
            {
                username = username.Text,
                password = password.Text
            };
            var jsonString = JsonConvert.SerializeObject(jsonObject);

            Console.WriteLine(jsonString);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var myHttpClient = new HttpClient();
            var response = await myHttpClient.PostAsync("http://192.168.254.120:8000/metro_events/login", content); 
            Console.WriteLine(response.IsSuccessStatusCode);

            if (response.IsSuccessStatusCode)
            {
                //var tokenJson = await response.Content.ReadAsStringAsync();
                /*Device.BeginInvokeOnMainThread(() => {
                    new NavigationPage(new EventView());
                });*/
                //await Navigation.PushAsync(new EventListView());
                //await NavigationPage(new EventView());
            //}
            //else
            //{
              //  Console.Write("ERROR");
               // await DisplayAlert("Login Status", "Wrong Username and Password","OK");
            //}
        //}
    }
}