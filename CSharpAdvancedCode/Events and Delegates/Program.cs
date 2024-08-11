using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events_and_Delegates
{
    //events has mainly classes -- publisher and subscribers
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
    public class Video
    {
        public string Title { get; set; }
    }

    // Publisher Class
    public class VideoEncoder
    {
        // 1 - Define delegate
        public delegate void VideoEncodedEventHandler(object source , VideoEventArgs args);
        

        // 2 - Define event based on the delegate
        public event VideoEncodedEventHandler VideoEncoded;

        // OR
        // (see note at end of code)
        // public event EventHandler<VideoEventArgs> VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);
            OnVideoEncoded(video);
        }

        // 3 - Raise the event 
        protected virtual void OnVideoEncoded(Video video) // publisher method -- always protected and virtual
        {
            if(VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs {Video = video } );
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////

    internal class Program
    {
        static void Main(string[] args)
        {
            var video = new Video { Title="abcd"};
            var encoder = new VideoEncoder(); //publisher 
            var mailService = new MailService(); // subscriber 

            encoder.VideoEncoded += mailService.OnVideoEncoded;  //subscription to event

            var messageService = new MessageService();
            encoder.VideoEncoded += messageService.OnVideoEncoded;

            encoder.Encode(video);  


        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////
    
    // Subscriber Classes
    public class MailService
    {
        // 5 -- catch event
        public void OnVideoEncoded(object source , VideoEventArgs args) 
        {
            Console.WriteLine("mail sent, vid encoded: "+args.Video.Title);
        }
    }

    public class MessageService
    {
        public void OnVideoEncoded(object source , VideoEventArgs args)
        {
            Console.WriteLine("message sent, video encoded: "+args.Video.Title);
        }
    }
}

// Note:
// Instead of defining a delegate everytime for events, we can use built-in delegate tailored for events
// 1. EventHandler    -- delegate with no args
// 2. EventHandler<TEventArgs> -- delegate with args