using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PagesActivity.Views;
using PagesActivity.Modelsege;

namespace PagesActivity.ViewModels
{
    class PersonalInfoViewModel
    {
        //string label;
        Command toEducation;
        string firstName, middleName, lastName, birthday, gender;

        public PersonalInfoViewModel() {
            toEducation = new Command(async () => {
                PersonInfo personalInfo = new PersonInfo();
                personalInfo.FirstName = firstName;
                personalInfo.MiddleName = middleName;
                personalInfo.LastName = lastName;
                personalInfo.Birthday = birthday;
                personalInfo.Gender = gender;

                await Application.Current.MainPage.Navigation.PushAsync(new EducationBackground(personalInfo));
            });
        }

        public Command ToEducation
        { 
            get { return toEducation;  }
            set { }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        /*public string Label { 
            get { return label; }
            set {}
        }*/
    }
}
