using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PagesActivity.Views;
using PagesActivity.Modelsege;

namespace PagesActivity.ViewModels
{
    class SkillsViewModel
    {
        Command backToEducation;
        Command toSummary;
        string skill1, skill2, skill3, skill4, skill5;
        PersonInfo personalInfo;

        public SkillsViewModel()
        {
            backToEducation = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(new EducationBackground());
            });

            toSummary = new Command(async () => {
                /*Console.WriteLine(personalInfo.FirstName);
                Console.WriteLine(personalInfo.MiddleName);
                Console.WriteLine(personalInfo.LastName);
                Console.WriteLine(personalInfo.Birthday);
                Console.WriteLine(personalInfo.Gender);

                Console.WriteLine(personalInfo.Elementary);
                Console.WriteLine(personalInfo.ElemYear);
                Console.WriteLine(personalInfo.HighSchool);
                Console.WriteLine(personalInfo.HsYear);
                Console.WriteLine(personalInfo.College);*/

                personalInfo.Skill1 = skill1;
                personalInfo.Skill2 = skill2;
                personalInfo.Skill3 = skill3;
                personalInfo.Skill4 = skill4;
                personalInfo.Skill5 = skill5;

                await Application.Current.MainPage.Navigation.PushAsync(new Summary(personalInfo));
            });
        }

        public Command BackToEducation
        {
            get { return backToEducation; }
            set { }
        }

        public Command ToSummary
        {
            get { return toSummary; }
            set { }
        }

        public PersonInfo PersonalInfo {
            get => personalInfo;
            set { personalInfo = value; }
        }


        public string Skill1
        {
            get { return skill1; }
            set { skill1 = value; }
        }

        public string Skill2
        {
            get { return skill2; }
            set { skill2 = value; }
        }

        public string Skill3
        {
            get { return skill3; }
            set { skill3 = value; }
        }

        public string Skill4
        {
            get { return skill4; }
            set { skill4 = value; }
        }

        public string Skill5
        {
            get { return skill5; }
            set { skill5 = value; }
        }
    }
}
