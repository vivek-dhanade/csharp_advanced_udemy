using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {

        }
    }
    public class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Photo photo);
        public void Process(string path, PhotoFilterHandler filterHandler, Action<Photo> filterHandler2)
        {
            var photo = Photo.Load(path);
            // var filters = new PhotoFilters();
            // filters.ApplyBrightness(photo);
            // filters.ApplyContrast(photo);
            // filters.Resize(photo);
            // photo.Save();

            // instead we use Delegate
            filterHandler(photo);

            //built-in delegates in .NET
            // System.Action<T> -- for void return
            // System.Func<T, T> -- for some return value (first T is input argument, second T is return type
            filterHandler2(photo);

        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply Brightness");
        }

        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply Contrast");
        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("Resize");
        }
    }


    /////////////////////////////////////////////////////////////////////////////
    
    internal class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filter = new PhotoFilters();

            PhotoProcessor.PhotoFilterHandler filterHandler = filter.ApplyContrast;
            filterHandler += filter.ApplyBrightness;
            filterHandler += RemoveRedEyeFilter;

            Action<Photo> filterHandler2 = filter.Resize;  // built-in Delegate in .NET
            processor.Process("photo.jpg", filterHandler, filterHandler2); 
        }

        // other developers can add their own customised function as extension to given program, thus giving extensibility and flexibility of code by using Delegates
        public static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Removed red eyes");
        }
    }


}
