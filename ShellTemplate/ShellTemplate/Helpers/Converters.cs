using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellTemplate.Helpers
{
    public static class Converters
    {
        public static string GetInitials(this string myString)
        {
            //  Define string separators, convert to uppercase and
            //  Split the input string into an array of words
            string[] separatorStrings = { " ", "  ", "." };
            string[] strSplit = myString.ToUpper().Split(separatorStrings, System.StringSplitOptions.RemoveEmptyEntries);

            //  Make a new output string from the first letter of each word in the input string
            string outputVal = String.Empty;
            foreach (var word in strSplit)
            {
                string a = word.Substring(0, 1);
                outputVal = outputVal + a;
            }

            //  return the output to the caller.
            return outputVal;
        }
    }
}
