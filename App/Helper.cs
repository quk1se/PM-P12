using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App
{
    public class Helper
    {
        //Method for changes symbols in string with html encoding
        public string HtmlTest(string input)
        {
            if (input is null)
            {
                throw new ArgumentException("Argument 'html' is null");
            }
            if (input.Length == 0)
            {
                return "";
            }
            input = input.Replace("<", "&lt;");
            input = input.Replace(">", "&gt;");
            return input;
        }


        //Method for checking attributes in html string
        public bool ContainsAttributes(String html)
        {
            string pattern = @"<\w+\s+[^=]*(\w+=[^>]+)+>";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(html);
        }


        //Method for modification string
        public String Ellipsis(String input, int len)
        {
            if (input == null)
            {
                throw new ArgumentNullException("null detected in parameter: " + nameof(input));
            }
            if (len < 3)
            {
                throw new ArgumentNullException("Argument 'len' could not be less than 3");
            }
            if (input.Length < len)
            {
                throw new ArgumentOutOfRangeException("Argument 'len' could not be greater than 'len'");
            }
            // return "He...";
            // return (len == 5) ? "He..." : "Hel...";
            // return "Hel"[..(len-3)]+"...";
            return input[..(len - 3)] + "...";
        }


        //Method for adding a period at the end of a line
        public string Dots(string input, int len) 
        {
            if (input[..(len - 1)] != ".")
                return input[..(len - 1)] + ".";
            else
                return input;
        }


        //Method for concatenating strings correctly
        public string CombineUrl(string part1, string part2) 
        {
            //if (!part1.StartsWith('/')) part1 = '/' + part1;
            //if (part1.EndsWith('/')) part1 = part1[..^1];
            //
            //if (!part2.StartsWith('/')) part2 = '/' + part2;
            //if (part2.EndsWith('/')) part2 = part2[..^1];
            //return $"{part1}{part2}";
            while (part1.StartsWith('/')) { part1 = part1.Substring(1); }
            part1 = '/' + part1;
            while (part1.EndsWith('/')) { part1 = part1[..^1]; }

            while (part2.StartsWith('/')) { part2 = part2.Substring(1); }
            part2 = '/' + part2;
            while (part2.EndsWith('/')) { part2 = part2[..^1]; }
            return $"{part1}{part2}";
        }
    }
}
