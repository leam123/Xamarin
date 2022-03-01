using System;
using System.Collections.Generic;
using System.Text;

namespace PagesActivity.Models
{
    public class Notes
    {
        public int Id { get; set; }
        public string Note { get; set; }

        public string ToString() {
            return Id + ": " + Note;
        }
    }
}
