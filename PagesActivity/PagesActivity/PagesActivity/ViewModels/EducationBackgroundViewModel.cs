using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PagesActivity.Views;
using PagesActivity.Modelsege;

namespace PagesActivity.ViewModels
{
    class EducationBackgroundViewModel
    {
        Command backToPersonal;
        Command toSkills;
        string elementary, highSchool, college;
        int eYear, hYear;
        PersonInfo personalInfo; //= new PersonInfo();

        public EducationBackgroundViewModel() {
            backToPersonal = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new PersonalInfo());
            });

            toSkills = new Command(async () => {
                //PersonInfo personal = new PersonInfo();
                /*Console.WriteLine(personalInfo.FirstName);
                Console.WriteLine(personalInfo.MiddleName);
                Console.WriteLine(personalInfo.LastName);
                Console.WriteLine(personalInfo.Birthday);
                Console.WriteLine(personalInfo.Gender);*/

                personalInfo.Elementary = elementary;
                personalInfo.ElemYear = eYear;
                personalInfo.HighSchool = highSchool;
                personalInfo.HsYear = hYear;
                personalInfo.College = college;

                await Application.Current.MainPage.Navigation.PushAsync(new Skills(personalInfo));
            });
        }

        public Command BackToPersonal {
            get { return backToPersonal; }
            set { }
        }

        public Command ToSkills {
            get { return toSkills; }
            set { }
        }

        public PersonInfo PersonalInfo {
            get => personalInfo;
            set { personalInfo = value; }
        }

        public string Elementary
        {
            get { return elementary; }
            set { elementary = value; }
        }

        public string HighSchool
        {
            get { return highSchool; }
            set { highSchool = value; }
        }

        public string College
        {
            get { return college; }
            set { college = value; }
        }

        public int EYear
        {
            get { return eYear; }
            set { eYear = value; }
        }

        public int HYear
        {
            get { return hYear; }
            set { hYear = value; }
        }

    }
}
