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
    public partial class Summary : ContentPage
    {
        PersonInfo personalInfo;
        public Summary()
        {
            InitializeComponent();
        }

        public Summary(PersonInfo p) {
            this.personalInfo = p;
            InitializeComponent();
            ((SummaryViewModel)BindingContext).PersonalInfo = p;

            fullname.Text = p.FirstName + " " + p.MiddleName + " " + p.LastName;
            birthday.Text = p.Birthday;
            gender.Text = p.Gender;

            elementary.Text = p.Elementary + ", " + p.ElemYear;
            highschool.Text = p.HighSchool + ", " + p.HsYear;
            college.Text = p.College + ", " + p.ColYear;

            skill1.Text = p.Skill1;
            skill2.Text = p.Skill2;
            skill3.Text = p.Skill3;
            skill4.Text = p.Skill4;
            skill5.Text = p.Skill5;
        }
    }
}