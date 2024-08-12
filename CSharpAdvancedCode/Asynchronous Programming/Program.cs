using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous_Programming
{
    // Synchronous Programming
    // Program is executed line by line,one at a time
    // When a function is called program has to wait until the function returns


    // Asynchronous Program Executiom
    // When a function is called, program execution continues to next line, without waiting for the function to complete

    // Real world examples -- Media Player -- various functionalities running simultaneously, Web Browser
    // Use Case: Accessing files, working with files and databases, working with images

    // How?
    // Traditional Approaches: 
    //      Multi-threading
    //      Callbacks
    // New Approach since .NET 4.5
    //      Async/Await

    // Asynchronous methods begin with "async" keyword and return type is "Task" object (either Task or Task<T>)
    // Task object -- encapsulates state of asynchronous application
    // Task<T> is used when there is a return value in the function


    public static class MainWindow //:  Window
    {
        //public MainWindow()
        //{
        //    InitializeComponent();
        //}

        public static async void Button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Before DownloadHtml Function Call");
            // Synchronous 
            // DownLoadHtml(@"https://msdn.microsoft.com");   
            // Asynchronous 
            DownloadHtmlAsync(@"https://msdn.microsoft.com");
            Console.WriteLine("After DownloadHtml Function Call");

        }


        ////Synchronous Execution
        //public static void DownLoadHtml(string url)
        //{
        //    var webClient = new WebClient();
        //    var html = webClient.DownloadString(url);

        //    using (var streamWriter = new StreamWriter(@"c:\users\E272830\Desktop\result.html"))
        //    {
        //        streamWriter.Write(html);
        //    }
        //    Console.WriteLine("Completed DownloadHtml Function Execution");
        //}

        //Asynchronous execution

        // Note: We change all built-in methods to their async contemporary as well
        public static async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            var html = await webClient.DownloadStringTaskAsync(url);     // await keyword used where we know the task will take time, so from this point on, the further execution will be asynchronous, and the calling method continues execution further until DownloadHtmlAsyn() returns some value after parallel execution

            using (var streamWriter = new StreamWriter(@"c:\users\E272830\Desktop\result.html"))
            {
                await streamWriter.WriteAsync(html);
            }
        }
        
        

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MainWindow.Button_Click(null, null);
        }
    }
}

// The methods/operations which require time to execute are called blocking operations as they block further execution of program 

// we use asynchronous execution for blocking operations/methods

// in web applications whenever user calls blocking operation, a thread is assigned to it which executes the operation while other threads continue further execution without waiting for the output of blocking operation

// there are limited no. of threads allocated to each user in server thus limited no. of blocking operations can be executed at a time

// if all threads get used out, server becomes unresponsive
// solution to this is deploying more servers -- called scaling