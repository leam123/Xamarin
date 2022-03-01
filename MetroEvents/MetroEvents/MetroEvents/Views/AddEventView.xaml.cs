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
    public partial class AddEventView : ContentPage
    {
       
        public AddEventView()
        {
            InitializeComponent();
        }

        public async void AddEvent(object sender, EventArgs e) {
            var jsonObject = new Event
            {
                name = name.Text,
                description = description.Text,
                startDateTime = startDateTime.Date,
                endDateTime = endDateTime.Date,
                upvotes = int.Parse(upvotes.Text),
                participantsCount = int.Parse(participantsCount.Text),
                type = type.Text,
                status = status.Text
            };
            var jsonString = JsonConvert.SerializeObject(jsonObject);

            Console.WriteLine(jsonString);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var myHttpClient = new HttpClient();
            HttpResponseMessage response = await myHttpClient.PostAsync("http://192.168.254.120:8000/metro_events/add-event", content).ConfigureAwait(false);

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