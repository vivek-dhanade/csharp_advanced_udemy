using System;
using System.Collections.Generic;


using System.Linq;

namespace LINQ
{
    public class Book
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book(){Title = "C# Advanced Topics", Price=9 },
                new Book(){Title = "ADO.NET step by step", Price=5 },
                new Book(){Title = "ASP.NET MVC", Price=9.99f },
                new Book(){Title = "ASP.NET Web API", Price=12 },
                new Book(){Title = "C# Advanced Topics", Price=7 }
            };
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new BookRepository().GetBooks();

            //var cheapBooks = new List<Book>();
            //foreach (var book in repo)
            //{
            //    if (book.Price < 10)
            //    {
            //        cheapBooks.Add(book);
            //    }
            //}

            // OR
            var cheapBooks = repo.Where((Book book) => book.Price < 10); // Where() extension method in LINQ
            //cheapBooks = cheapBooks.OrderBy(book => book.Title); // OrderBy() extension method in LINQ

            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book.Title + " "+ book.Price);
            }

            Console.WriteLine();


            // Select() extension method in LINQ
            var cheapBooksTitle = cheapBooks
                                            .Select((Book book) => book.Title);
            foreach (var book in cheapBooksTitle)
            {
                Console.WriteLine(book);
            }



            //LINQ Query Operators
            var cheapestBooks = from book in repo
                                where book.Price < 5
                                orderby book.Title
                                select book;
            // just like SQL queries -- always start with "from" and ends with "select"


            Console.WriteLine();


            // LINQ Extension Methods 
            //Single()
            var bookMVC = repo.Single(b => b.Title == "ASP.NET MVC");
            Console.WriteLine(bookMVC.Title +" "+ bookMVC.Price);
            Console.WriteLine();

            //SingleOrDefault()
            var bookMVCIfPresent = repo.SingleOrDefault(b => b.Title == "ASP.NET MVC++");
            Console.WriteLine(bookMVCIfPresent == null);
            Console.WriteLine();

            //First()
            var firstBook = repo.First();
            Console.WriteLine(firstBook.Title);
            Console.WriteLine();

            var firstBookWithTitleCondition = repo.First(b => b.Title == "C# Advanced Topics");
            Console.WriteLine(firstBookWithTitleCondition.Title + " " + firstBookWithTitleCondition.Price);
            Console.WriteLine();

            //FirstOrDefault()
            var firstOrDefault = repo.FirstOrDefault(b => b.Title == "abc");
            Console.WriteLine(firstOrDefault == null);
            Console.WriteLine();

            //Last()
            //LastOrDefault() -- same implementation as First() and FirstOrDefault()


            //Skip() and Take()
            var skipAndTakeBooks = repo.Skip(2).Take(3);
            foreach (var item in skipAndTakeBooks)
            {
                Console.WriteLine(item.Title);
            }
            Console.WriteLine();

            //Count()
            Console.WriteLine(skipAndTakeBooks.Count());
            Console.WriteLine();

            //Max() 
            Console.WriteLine(repo.Max(b=> b.Price));
            Console.WriteLine();

            //Min()
            Console.WriteLine(repo.Min(b=> b.Price));
            Console.WriteLine();

            //Sum()
            Console.WriteLine(repo.Sum(b=> b.Price));
        }
    }
}
