using System;
using System.Collections.Generic;

namespace Question2
{
    class Program
    {
        static void Main(string[] args)
        {
            BookMethods bookMethods = new BookMethods();
            
            Console.WriteLine("READ BOOKS");
            
            //Testing the ReadBooks method
            List<Book> books =
                bookMethods.ReadBooks(
                    "Book:\nAuthor: Brian Jensen\nTitle: Texts from Denmark\nPublisher: Gyldendal\nPublished: 2001\n\n" +
                    "Book:\nAuthor: Peter Jensen\nAuthor: Hans Andersen\nTitle: Stories from abroad\nPublisher: Borgen\nPublished: 2012\n"+
                    "Book:\nAuthor: Peter Parker\nAuthor: Hans Solo\nAuthor: John Doe\nTitle: Stories from Space\nPublisher: Lucas\nPublished: 1999");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine("Accessing: "+books[i].ToString());
            }

            Console.WriteLine("\nFIND BOOKS");
            
            //Testing the FindBook method
            //Test case 1: "*20*"
            //Test case 2: "*20* & *Peter*"
            //Test case 3: "*Stories* & *Peter* & *Space*"
            List<Book> searchedBooks = bookMethods.FindBooks("*20* & *Peter*");
            foreach (var b in searchedBooks)
            {
                Console.WriteLine("Found: "+b.ToString());
            }

        }
    }
}