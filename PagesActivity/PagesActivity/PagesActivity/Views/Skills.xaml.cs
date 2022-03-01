using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PagesActivity.Modelsege;
using PagesActivity.ViewModels;

namespace PagesActivity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Skills : ContentPage
    {
        PersonInfo personalInfo;
        public Skills()
        {
            InitializeComponent();
        }

        public Skills(PersonInfo p)
        {
            this.personalInfo = p;
            InitializeComponent();
            ((SkillsViewModel)BindingContext).PersonalInfo = p;
        }
    }
}