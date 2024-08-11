using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Expressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // args => expressions

            Func<int, int> func = (int number) => number * number;

            Console.WriteLine(func(5));

            var books = new BookRepository().GetBooks();

            var cheapBooks= books.FindAll((Book book) => book.Price > 486); // findAll() is built-in function , called predicate functions

            foreach ( var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }
        }
    }

    public class Product
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class Book : Product
    {
        public string Isbn { get; set; }
    }

    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() {Title="A", Price = 486},
                new Book() {Title="B", Price = 487},
                new Book() {Title="C", Price = 488},
            };
        }

    }
}
