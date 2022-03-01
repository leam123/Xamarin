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
    public partial class EducationBackground : ContentPage
    {
        PersonInfo personalInfo;
        public EducationBackground()
        {
            InitializeComponent();
        }

        public EducationBackground(PersonInfo p)
        {
            this.personalInfo = p;
            InitializeComponent();
            ((EducationBackgroundViewModel)BindingContext).PersonalInfo = p;
        }
    }
}