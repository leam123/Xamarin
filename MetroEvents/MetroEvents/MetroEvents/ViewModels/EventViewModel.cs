using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using MetroEvents.Models;
using MetroEvents.Views;

using System.Net.Http;
using Newtonsoft.Json;

namespace MetroEvents.ViewModels
{
    class EventViewModel : BaseViewModel
    {
        Command addEventBtn;

        
        public EventViewModel()
        {
            addEventBtn = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new AddEventView());
            });

        }

        public Command AddEventBtn
        {
            get { return addEventBtn; }
            set { }
        }

        /*public async void GetEvents()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://192.168.254.120:8000/metro_events/event-list");
            var events = JsonConvert.DeserializeObject<List<Event>>(response);

            EventList.ItemsSource = events;
        }*/
    }
}
