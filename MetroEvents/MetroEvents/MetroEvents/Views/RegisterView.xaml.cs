using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MetroEvents.Models;

using Newtonsoft.Json;
using System.Net.Http;

namespace MetroEvents.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterView : ContentPage
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        public async void AddUser(object sender, EventArgs e)
        {
            var jsonObject = new User
            {
                first_name = fname.Text,
                last_name = lname.Text,
                username = username.Text,
                password = password.Text,
                email = email.Text
            };
            var jsonString = JsonConvert.SerializeObject(jsonObject);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var myHttpClient = new HttpClient();
            HttpResponseMessage response = await myHttpClient.PostAsync("http://192.168.254.120:8000/metro_events/register", content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var tokenJson = await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.Write("ERROR");
            }
        }
    }
}