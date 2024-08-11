using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic
{
    // C# Originally Static Typed Language ( Type resolution at compile time)
    // Dynamic Typed Feature added to C# after .NET 4 ( Dynamic Typed Lang. -- Type Resolution at run-time

    internal class Program
    {
        static void Main(string[] args)
        {
            object obj = "Mosh";
            //obj.GetHashCode()

            ////with reflection -- for dynamicity
            //var methodInfo = obj.GetType().GetMethod("GetHashCode");
            //methodInfo.Invoke(null, null);

            //// with dynamic keyword -- added with .NET 4 and DLR(Dynamic Language Runtime) complementing already existing CLR (Common Language Runtime)
            //dynamic excelObject = "mosh";
            //excelObject.Optimize();

            // dynamic typing allows different data types assigning to same variable
            dynamic name = "mosh";
            name = 10;

            //name = "mosh2";
            //name++; //gives runtime error instead of compiletime error

            dynamic a = 5;
            dynamic b = 10;
            var c = a + b; // c becomes dynamic type as a and b both are dynamic


            //at runtime dynamic type is implicitly convertible to target type
            float fl = 9.99f;
            dynamic f = fl;
            double d = f;
        }
    }
}
