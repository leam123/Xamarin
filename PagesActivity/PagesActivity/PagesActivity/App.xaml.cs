using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PagesActivity.Views;

namespace PagesActivity
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new UserView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
