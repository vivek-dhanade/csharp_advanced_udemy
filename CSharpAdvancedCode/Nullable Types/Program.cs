using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable_Types
{
    // ******************** Nullable Types ********************

    // Nullable types are defined using generic Nullable<T> 
    internal class Program
    {
        static void Main(string[] args)
        {

            Nullable<DateTime> date = null;

            // OR 
            // Short hand representation of Nullable type
            DateTime? date2 = null;


            // Member methods in Nullable Types
            Console.WriteLine("GetValueOrDefault(): " + date.GetValueOrDefault());
            Console.WriteLine("Has Value: " + date.HasValue);
            // Console.WriteLine("Value: " + date.Value );  -- gives error as value is null


            // Null Coalescing Operator
            DateTime date3;

            //if(date != null)
            //{
            //    date3 = date.Value;
            //}
            //else
            //{
            //    date3 = DateTime.Today;
            //}

            //instead using Null Coalescing Operator "??"
            date3 = date ?? DateTime.Today;

            Console.WriteLine(date3);


        }
    }
}
