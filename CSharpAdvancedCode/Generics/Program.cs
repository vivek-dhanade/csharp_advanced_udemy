using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    //******************** Section 2 : Generics ********************


    // General Implementation without Generics -- has code repetition
    public class Product
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class Book : Product
    {
        public string Isbn { get; set; }
    }

    public class BookList
    {
        private List<Book> bookList = new List<Book>();
        public void Add(Book book)
        {
            bookList.Add(book);
        }

        public Book this[int index]
        {
            get { return bookList[index]; }
        }
    }
    //likewise other products classes can be defined (notepad, notepadlist, sharpner, sharpnerlist etc) -- code repeats in these cases


    // Other method: Implementation using Objects(the parent of all data types) -- solves code repetition but has boxing unboxing overhead

    public class ObjectList
    {
        private List<Object> objectList = new List<Object>();

        public void Add(object obj)
        {
            objectList.Add(obj);
        }

        public Object this[int index]
        {
            get { return objectList[index]; }
        }
    }


    // Efficient method: Implementation using Generics

    public class GenericList<T> // T datatype is defined in Main method
    {
        private List<T> genericList = new List<T>();
        public void Add(T value)
        {
            genericList.Add(value);
        }

        public T this[int index]
        {
            get { return genericList[index]; }
        }
    }    

    //Implementing dictionary using Generics

    public class GenericDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> genericDictionary = new Dictionary<TKey, TValue>();

        public void Add(TKey key, TValue value)
        {
            genericDictionary.Add(key, value);
        }

        public TValue this[TKey key]
        {
            get { return genericDictionary[key]; }
        }
    }
    ///////////////////////////////////////////////////

    // Adding constraints to T in Generics

    public class Utilities
    {
        public T Max<T>(T a, T b) where T : IComparable
        {
            // return a > b ? a : b;
            return a.CompareTo(b) > 0 ? a : b;
        }

        // Also note here that a generic method is created in non generic class
    }

    //Constraint Types:
    // where T : IComparable     -- define functionality
    // where T : Product         -- define T as of type Product or its sub-classes
    // where T : struct          -- define T as value type data type
    // where T : class           -- define T as reference type data type
    // where T : new()           -- define T as object with default constructor 

    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CalculateDiscount(TProduct product)
        {
            return (float)(product.Price * 0.1);
        }
    }

    public class Nullable<T> where T: struct
    {
        private readonly object _value;

        public Nullable()
        {

        }
        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue()
        {
            return _value != null;
        }

        public T GetValueOrDefault()
        {
            if(HasValue())
                return (T)_value;
            else
                return default(T);
        }
    }


    public class Utilities2
    {
        public void CreateObj<T>() where T : new()
        {
            var obj = new T();
        }
    }




    //////////////////////////////////////////////////
    public class Program
    {
        static void Main(string[] args)
        {
            // General Implementation without generics
            var book = new Book { Isbn = "1111", Title = "C# Advanced" };

            var books = new BookList(); 
            books.Add(book);



            // With generics

            var book2 = new Book { Isbn = "4545", Title = "Abcde" };

            var books2 = new GenericList<Book>(); // here T is defined as type "Book"
            books2.Add(book2);
            // we can similarly implement for other products by defining T as type "notepad" , "sharpner" etc and
            // AVOIDING creating "notepadlist" and "sharpnerlist".
            // by using GenericList<T>
            //Also avoids boxing and unboxing by using T.

            var numbers = new GenericList<int>();
            numbers.Add(1);
            numbers.Add(2);

            var book3 = new Book { Isbn = "1124", Title = "Book3" };
            var bookList = new BookList();

            var dictionary = new GenericDictionary<string, BookList>();
            dictionary.Add("1234", bookList);
            dictionary["1234"].Add(book3);
            Console.WriteLine(dictionary["1234"][0].Title);


            // Constraints with Generics

            var utility = new Utilities();
            Console.WriteLine(utility.Max(4, 5));

            var nullable = new Nullable<int>();
            Console.WriteLine("Has Value: "+ nullable.HasValue());
            Console.WriteLine("Value: "+nullable.GetValueOrDefault());
        }
    }
}
