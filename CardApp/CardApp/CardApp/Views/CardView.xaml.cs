using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;
using CardApp.ViewModels;
using CardApp.Views;
using CardApp.Models;
using System.Net.Http;

namespace CardApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardView : ContentPage
    {
        static string token;

        public CardView()
        {
            InitializeComponent();
        }

        public async void GetCard(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            //var response = await httpClient.GetStringAsync("http://www.hyeumine.com/getcard.php?bcode=HEelhJos");
            var response = await httpClient.GetStringAsync("http://www.hyeumine.com/getcard.php?bcode=" + bCode.Text);

            if (response != "0")
            {
                await DisplayAlert("Generating Your Card", "Code is being processed. Please Wait.", "OK");

                bCode.IsEnabled = false;
                submit.IsEnabled = false;

                var cards = JsonConvert.DeserializeObject<Cards>(response);

                Button[] btnsForB = { B1, B2, B3, B4, B5 };
                Button[] btnsForI = { I1, I2, I3, I4, I5 };
                Button[] btnsForN = { N1, N2, N3, N4, N5 };
                Button[] btnsForG = { G1, G2, G3, G4, G5 };
                Button[] btnsForO = { O1, O2, O3, O4, O5 };

                for (int i = 0; i < 5; i++)
                {
                    btnsForB[i].Text = cards.card.B[i].ToString();
                    btnsForI[i].Text = cards.card.I[i].ToString();
                    btnsForN[i].Text = cards.card.N[i].ToString();
                    btnsForG[i].Text = cards.card.G[i].ToString();
                    btnsForO[i].Text = cards.card.O[i].ToString();
                }

                token = cards.playcard_token;

                Console.WriteLine("TOKEN GENERATED");
                Console.WriteLine(cards.playcard_token);
                Console.WriteLine(token);
            }
            else
            {
                await DisplayAlert("Bingo Code is Invalid", "Enter New One", "OK");
            }
        }

        public void MarkCard(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            string btnText = btn.Text;

            if (btnText == "60" || btnText == "43" || btnText == "66" || btnText == "28" || btnText == "7")
            {
                Console.WriteLine(btnText);
                btn.BackgroundColor = Color.FromHex("#808080");
                btn.IsEnabled = false;
            }
            else
            {
                Console.WriteLine(btnText);
            }
        }

        public async void BingoCheck(object sender, EventArgs e)
        {

            Console.WriteLine("THIS IS YOUR PLAYCARD TOKEN!");
            Console.WriteLine(token);

            Button[] allBtns = { B1, B2, B3, B4, B5,
                I1, I2, I3, I4, I5,
                N1, N2, N3, N4, N5,
                G1, G2, G3, G4, G5,
                O1, O2, O3, O4, O5 };

            bool allFalse = true;

            foreach (var item in allBtns)
            {
                if (item.IsEnabled == false) {
                    allFalse = true;
                    continue;
                }
                else
                {
                    await DisplayAlert("Not Yet", "You cannot win since you haven't cleared your bingo card yet.", "Go Back");
                    allFalse = false;
                    break;
                }
            }

            if (allFalse)
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync("http://www.hyeumine.com/checkwin.php?playcard_token=" + token);

                if (response == "1")
                {
                    await DisplayAlert("MASTER OF GAMBLE!", "Congratulations, You Win!", "OK");
                }
                else
                {
                    await DisplayAlert("Card Token Not Found", "Not a valid bingo card", "OK");
                }
            }
        }
    }
}