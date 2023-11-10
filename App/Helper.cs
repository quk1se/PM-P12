﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Helper
    {
        public String Ellipsis(String input, int len)
        {
            // return "He...";
            // return (len == 5) ? "He..." : "Hel...";
            // return "Hel"[..(len-3)]+"...";
            return input[..(len - 3)] + "...";
        }
        public string Dots(string input, int len)
        {
            if (input[..(len - 1)] != ".")
                return input[..(len - 1)] + ".";
            else
                return input;
        }
    }
}
