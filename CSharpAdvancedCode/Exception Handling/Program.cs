using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling
{
    // stack trace -- the description of Methods and Code Line which resulted into Exception -- on output console
    //eg.
    // Unhandled Exception: System.DivideByZeroException: Attempted to divide by zero.
    //    at Exception_Handling.Calculator.Divide(Int32 numerator, Int32 denominator) in C:\Users\E272830\Desktop
    //    \csharp_advanced_udemy\CSharpAdvancedCode\Exception Handling\Program.cs:line 14
    //   at Exception_Handling.Program.Main(String[] args) in C:\Users\E272830\Desktop\csharp_advanced_udemy
    //   \CSharpAdvancedCode\Exception Handling\Program.cs:line 22
    // 

    public class Calculator
    {
        public int Divide(int numerator, int denominator)
        {
            return numerator / denominator;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    var calculator = new Calculator();
            //    var result = calculator.Divide(5, 0);
            //}
            //catch (DivideByZeroException e)
            //{

            //}
            //catch (ArithmeticException e)
            //{

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Sorry an unexpected error occured.");
            //}
            //finally // used for garbage collection and data cleanup -- release allocated resources
            //{

            //}

            //// Always represent Exceptions in hierarchy -- here, DivideByZeroException class belongs to ArithmeticException class which in turn belongs to System.Exception class

            //StreamReader streamReader = null;

            //try
            //{
            //    using (streamReader = new StreamReader(@"C:\obj.txt"))
            //    {
            //        var content = streamReader.ReadToEnd();
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Sorry an unexpected error occured.");
            //}
            //finally
            //{
            //    streamReader.Dispose();
            //}


            try
            {
                var api = new YoutubeAPI();
                var video = api.GetVideos("mosh");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    //Custom Exceptions
    public class Video
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Size { get; set; }
    }
    public class YoutubeAPI
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                // Access the web service
                // Read the data
                // Create list of Video Objects
                throw new Exception("Neww error here. ");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message+ "Could not fetch the videos from Youtube." );
            }

            return new List<Video>();

        }
    }

}
