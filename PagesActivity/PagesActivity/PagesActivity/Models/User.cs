using System;
using System.Collections.Generic;
using System.Text;

namespace PagesActivity.Models
{
    public class User
    {
        public int Id;
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string ToString()
        {
            return Id + ": ";
        }

    }
}