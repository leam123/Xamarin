using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CardApp.Views;

namespace CardApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CardView();
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
