using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Methods
{
    public static class StringExtensions
    {
        public static string Shorten(this String str, int numberOfWords) // "this String str" isn't an input attribute but defines the data type on which this static extension method can be applied on
        {
                
            if(numberOfWords ==0 )
                return "";

            var words = str.Split(' ');

            if(words.Length < numberOfWords )
                return str;
            
            return string.Join(" ", words.Take(numberOfWords)) + "..."; //Take() is inbuilt function
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "this is supposed to be a very long blog post ancdefghij kilumf";

            Console.WriteLine(str.Shorten(5));  // using extension method Shorten() here
        }
    }
}

