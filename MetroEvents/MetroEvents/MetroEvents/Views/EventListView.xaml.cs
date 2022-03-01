using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using MetroEvents.Models;

using System.Net.Http;
using Newtonsoft.Json;

namespace MetroEvents.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventListView : ContentPage
    {
        public EventListView()
        {
            InitializeComponent();
            GetEvents();
        }

        public async void GetEvents()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://192.168.254.120:8000/metro_events/event-list");
            var events = JsonConvert.DeserializeObject<List<Event>>(response);

            Console.WriteLine(events);

            EventList.ItemsSource = events;
        }
    }
}