using System;
using System.Collections.Generic;
using System.Text;

namespace PagesActivity.Modelsege
{
    public class PersonInfo
    {
        string firstName, middleName, lastName, birthday;
        string gender, elementary, highSchool, college, colYear;
        int elemYear, hsYear;
        string skill1, skill2, skill3, skill4, skill5;

        /*public PersonInfo(string fname){
            firstName = fname;
        }*/

        public string FirstName {
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

        public int ElemYear {
            get { return elemYear; }
            set { elemYear = value; }
        }

        public int HsYear
        {
            get { return hsYear; }
            set { hsYear = value; }
        }

        public string ColYear
        {
            get { return "Present"; }
            set { colYear = "Present"; }
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
