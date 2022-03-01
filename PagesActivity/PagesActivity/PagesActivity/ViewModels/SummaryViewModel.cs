using System;
using System.Collections.Generic;
using System.Text;
using PagesActivity.Modelsege;

namespace PagesActivity.ViewModels
{
    class SummaryViewModel
    {
        PersonInfo personalInfo;

        public SummaryViewModel() {

        }

        public PersonInfo PersonalInfo {
            get => personalInfo;
            set { 
                personalInfo = value; 
            }
        }

    }
}
