using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace CardApp.Models
{
    public class Cards
    {
        public Cards(){}
        public string playcard_token { get; set; }
        public Number card { get; set; }
    }

    public class Number {  

        public Number() { }
        public ArrayList B { get; set; }
        public ArrayList I { get; set; }
        public ArrayList N { get; set; }
        public ArrayList G { get; set; }
        public ArrayList O { get; set; }
    }
}
