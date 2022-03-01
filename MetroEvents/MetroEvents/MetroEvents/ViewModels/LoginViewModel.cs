using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using MetroEvents.Models;
using MetroEvents.Views;

using System.Net.Http;
using Newtonsoft.Json;

namespace MetroEvents.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        Command register;
        Command login;
        string username, password;

        public LoginViewModel() {
            register = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new RegisterView());
            });

            login = new Command(async () => {
                var jsonObject = new User
                {
                    username = username,
                    password = password
                };
                var jsonString = JsonConvert.SerializeObject(jsonObject);

                Console.WriteLine(jsonString);

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync("http://192.168.254.120:8000/metro_events/login", content);


                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new EventListView());
                }
                else { }
            });
        }

        public Command Register
        {
            get { return register; }
            set { }
        }

        public Command Login
        {
            get { return login; }
            set { }
        }

        public string Username {
            get { return username; }
            set {
                username = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }

        /*public async void LoginOnApp()
        {
            var jsonObject = new User
            {
                username = username,
                password = password
            };
            var jsonString = JsonConvert.SerializeObject(jsonObject);

            Console.WriteLine(jsonString);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var myHttpClient = new HttpClient();
            var response = await myHttpClient.PostAsync("http://192.168.254.120:8000/metro_events/login", content);


            if (response.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new EventListView());
            }
        }*/
    }
}
