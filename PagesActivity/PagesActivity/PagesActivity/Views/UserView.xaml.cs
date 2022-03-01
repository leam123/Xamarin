using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using PagesActivity.Models;

using System.Net.Http;
using Newtonsoft.Json;

namespace PagesActivity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserView : ContentPage
    {
        public UserView()
        {
            InitializeComponent();
            AddUser();
        }
        public async void AddUser()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://www.hyeumine.com");

            string jsonData = @"{""firstname"" : ""leamor"", ""lastname"" : ""garcia""}"; 

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("/newuser.php", content);
           
            var result = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine(result);
        }
    }
}