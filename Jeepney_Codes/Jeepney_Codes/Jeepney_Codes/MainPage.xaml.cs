using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Jeepney_Codes
{
    public partial class MainPage : ContentPage
    {
        Dictionary<string, ArrayList> routeList = new Dictionary<string, ArrayList>();

        public MainPage()
        {
            InitializeComponent();

            routeList.Add("01A", new ArrayList() { "Alpha", "Bravo", "Charlie", "Echo", "Golf" });
            routeList.Add("02B", new ArrayList() { "Alpha", "Charlie", "Delta", "Foxtrot", "Golf" });
            routeList.Add("03C", new ArrayList() { "Charlie", "Delta", "Foxtrot", "Hotel", "India" });
            routeList.Add("04A", new ArrayList() { "Charlie", "Delta", "Echo", "Foxtrot", "Golf" });
            routeList.Add("04D", new ArrayList() { "Charlie", "Echo", "Foxtrot", "Golf", "India" });
            routeList.Add("06B", new ArrayList() { "Delta", "Hotel", "Juliet", "Kilo", "Lima" });
            routeList.Add("06D", new ArrayList() { "Delta", "Foxtrot", "Golf", "India", "Kilo" });
            routeList.Add("10C", new ArrayList() { "Foxtrot", "Golf", "Hotel", "India", "Juliet" });
            routeList.Add("10H", new ArrayList() { "Foxtrot", "Hotel", "Juliet", "Lima", "November" });
            routeList.Add("11A", new ArrayList() { "Foxtrot", "Golf", "Kilo", "Mike", "November" });
            routeList.Add("11B", new ArrayList() { "Foxtrot", "Golf", "Lima", "Oscar", "Papa" });
            routeList.Add("20A", new ArrayList() { "India", "Juliet", "November", "Papa", "Romeo" });
            routeList.Add("20C", new ArrayList() { "India", "Kilo", "Lima", "Mike", "Romeo" });
            routeList.Add("42C", new ArrayList() { "Juliet", "Kilo", "Lima", "Mike", "Oscar" });
            routeList.Add("42D", new ArrayList() { "Juliet", "November", "Oscar", "Quebec", "Romeo" });

            /*routeList.Add("Alpha", new ArrayList() { "01A", "02B" });
            routeList.Add("Bravo", new ArrayList() { "01A" });
            routeList.Add("Charlie", new ArrayList() { "01A", "02B", "03C", "04A", "04D" });
            routeList.Add("Delta", new ArrayList() { "02B", "03C", "04A", "06B", "06D" });
            routeList.Add("Echo", new ArrayList() { "01A", "02A" });
            routeList.Add("Foxtrot", new ArrayList() { "02B", "03C", "04A", "04D", "06D", "10C", "10H", "11A", "11B" });
            routeList.Add("Golf", new ArrayList() { "01A", "02B", "04A", "04D", "06D", "10C", "11A", "11B" });
            routeList.Add("Hotel", new ArrayList() { "03C", "06B", "10C", "10H" });
            routeList.Add("India", new ArrayList() { "03C", "04D", "06D", "10C", "20A", "20C" });
            routeList.Add("Juliet", new ArrayList() { "06B", "10C", "10H", "20A", "42C", "42D" });
            routeList.Add("Kilo", new ArrayList() { "06B", "06D", "11A", "20C", "42C" });
            routeList.Add("Lima", new ArrayList() { "06B", "10H", "11B", "20C", "42C" });
            routeList.Add("Mike", new ArrayList() { "11A", "20C", "42C" });
            routeList.Add("November", new ArrayList() { "10H", "11A", "20A", "42D" });
            routeList.Add("Oscar", new ArrayList() { "11B", "42C", "42D" });
            routeList.Add("Papa", new ArrayList() { "11B", "20A" });
            routeList.Add("Quebec", new ArrayList() { "42D" });
            routeList.Add("Romeo", new ArrayList() { "20A", "20C", "42D" });*/
        }

        void GenerateRoute(object sender, EventArgs e) {
            string jeepCode = this.jeepneyCode.Text.ToUpper();

            if (isPattern(jeepCode))
            {
                Array codes = IdentifyCode(jeepCode);
                this.jeepneyRoute.Text = "";
                foreach (KeyValuePair<string, ArrayList> pair in routeList)
                {
                    string key = pair.Key;
                    ArrayList values = pair.Value;

                    if (codes.Length == 1)
                    {
                        if (codes.GetValue(0).ToString() == key)
                        {
                            foreach (string val in values)
                            {
                                this.jeepneyRoute.Text += val + " <--> ";
                            }
                        }
                    }
                    else
                    {
                        foreach (string code in codes)
                        {
                            if (code == key)
                            {
                                this.jeepneyRoute.Text += key + " => " + values[0] + " <-> " + values[1] + " <-> " + values[2] + " <-> " + values[3] + " <-> " + values[4] + ", ";
                            }
                        }
                    }

                    /*if (codes.Length == 1)
                    {
                        foreach (string val in values)
                        {
                            if (codes.GetValue(0).ToString() == val)
                            {
                                this.jeepneyRoute.Text += key + " <--> ";
                            }
                        }
                    }
                    else {
                        foreach (string code in codes) {
                            foreach (string val in values)
                            {
                                if (code == val)
                                {
                                    this.jeepneyRoute.Text += key + " <--> ";
                                }
                            }
                        }
                    }*/
                }
            }
            else {
                this.jeepneyRoute.Text = "Wrong Pattern. Please try to enter correct pattern (i.e. 01A or 01A,03C,06B).";
            }

        }

        private Array IdentifyCode(string str) {
            string[] codes = str.Split(',');
            return codes;
        }

        private bool isPattern(string str) {
            Regex pattern = new Regex (@"^[0-9]{2}[a-zA-Z]{1}");

            if (pattern.IsMatch(str))
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
