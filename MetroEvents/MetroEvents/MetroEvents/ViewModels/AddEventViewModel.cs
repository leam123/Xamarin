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
    class AddEventViewModel : BaseViewModel
    {
        Command back;

        /*string name, description, type, status;
        int participantsCount, upvotes;
        DateTime startDateTime, endDateTime;*/

        public AddEventViewModel()
        {
            back = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new EventListView());
            });
        }

        public Command Back
        {
            get { return back; }
            set { }
        }

        /*public async void AddEvent()
        {
            Console.WriteLine("Hello World!!!!");
            var jsonObject = new Event
            {
                Name = name,
                Description = description,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime,
                Upvotes = upvotes,
                ParticipantsCount = participantsCount,
                Type = type,
                Status = status
            };
            var jsonString = JsonConvert.SerializeObject(jsonObject);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var myHttpClient = new HttpClient();
            HttpResponseMessage response = await myHttpClient.PostAsync("http://192.168.254.120:8000/metro_events/add-event", content);

            if (response.IsSuccessStatusCode)
            {
                var tokenJson = await response.Content.ReadAsStringAsync();
                Console.Write(tokenJson);
            }
            else
            {
                Console.Write("ERROR");
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description {
            get { return description; }
            set { description = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public int Upvotes {
            get { return upvotes; }
            set { upvotes = value;  }
        }

        public int ParticipantsCount
        {
            get { return participantsCount; }
            set { participantsCount = value; }
        }

        public DateTime StartDateTime { 
            get { return startDateTime; }
            set { startDateTime = value; }
        }

        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; }
        }*/
    }
}
