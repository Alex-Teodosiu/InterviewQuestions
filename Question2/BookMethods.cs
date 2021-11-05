using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Question2
{
    public class BookMethods
    {
        private readonly List<Book> Books;
        
        public BookMethods()
        {
            Books = new List<Book>();
        }

        public List<Book> ReadBooks(string input)
        {
            //Store some data about the book in these variables before putting them in the Book constructor
            List<string> authors = new List<string>();
            string title = "", publisher = "";

            //Using the Split method to divide the string into an array of strings
            //A new element will be created after each new line
            string[] words = input.Split('\n');

            //Going through all string elements from the newly created array
            foreach (var w in words)
            {
                //Adding to list of authors if that element contains "Author"
                 if (w.Contains("Author:"))
                {
                    //Remove the string "Author:" at the beginning of the string element
                    var x = w.Replace("Author:", "");
                    //Add element to list of authors
                    authors.Add(x);
                }
                 //Adding a value to the local variable 'title' if that element from the array 'words' contains "Author"
                else if (w.Contains("Title:"))
                {
                    var x = w.Replace("Title:", "");
                    title = x;
                }
                else if (w.Contains("Publisher:"))
                {
                    //Remove the beginning of string using the Remove method
                    var x = w.Remove(0, "Publisher:".Length);
                    publisher = x;
                }
                else if (w.Contains("Published:"))
                {
                    var x = w.Replace("Published:", "");
                    //Converting a string to integer 
                    int publicationYear = Convert.ToInt16(x);
                    
                    //Instantiating the book and adding it to a collection of books that will be returned at end of method
                    //Create a deep copy of the author string list using a static method at the bottom of the class
                    Books.Add(new Book(Duplicate(authors), title, publisher, publicationYear));
                    //Clearing authors so that new authors can be inserted in a new book
                    authors.Clear();
                }
            }
            return Books;
        }

        public List<Book> FindBooks(string searchString)
        {
            //Using the Split method to divide the string into an array of strings
            string[] searchedItems = searchString.Split('*');
            //Remove empty elements using linq 
            searchedItems = searchedItems.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            //Creating a collection that will be returned at the end of the method
            List<Book> foundBooks = new List<Book>();
            //Creating a variable that will indicate is the & logical operation will be used to join a list of queries
            bool joinQueries = false;
            
            
            //Establishing whether it is necessary to join queries 
            foreach (var s in searchedItems)
            {
                if (s.Contains("&"))
                {
                    //Using LINQ to store string elements related to the query and remove the boolean operators
                    searchedItems = searchedItems.Where(x => !x.Contains("&")).ToArray();
                    joinQueries = true;
                }
            }
            
            //Going through all books
            foreach (var b in Books)
            {
                //Creating variable that will become false if a search item is not found in a book
                bool canProceed = true;
                //Going through search items
                for (var index = 0; index < searchedItems.Length; index++)
                {
                    var s = searchedItems[index];
                    
                    //Searching for books using a '&' Boolean operation joining the two queries
                    if (joinQueries & canProceed)
                    {
                        //if the searched item isn't found, then we can't proceed to search this book and won't save it to List
                        if(!(b.ContainsAuthor(s) | b.GetTitle().Contains(s) | b.GetPublisher().Contains(s) |
                             (int.TryParse(s, out int _) & b.GetPublicationYear().ToString().Contains(s))))
                        {
                            canProceed = false;
                        }
                        /*else if (b.ContainsAuthor(s) | b.GetTitle().Contains(s) | b.GetPublisher().Contains(s) |
                            (int.TryParse(s, out int _) & b.GetPublicationYear().ToString().Contains(s)))
                        {
                            canProceed = true;
                        }*/
                        //if we reach the end of the search items and all are present in book, then add book to List
                        if (index == searchedItems.Length - 1 & canProceed)
                        {
                            foundBooks.Add(b);
                            //Console.WriteLine("We have added to the list because of and: " + b.ToString());
                        }
                        
                    }
                    
                    //Searching for books without using '&' 
                    else if (!joinQueries)
                    {
                        //if any search item is present then we add it to the list of found books
                        if (b.ContainsAuthor(s) | b.GetTitle().Contains(s) | b.GetPublisher().Contains(s) |
                            (int.TryParse(s, out int _) & b.GetPublicationYear().ToString().Contains(s)))
                        {
                            foundBooks.Add(b);
                        }
                    }
                }
            }

            return foundBooks;
        }
        
        //this static method is used to create a deep copy of the author string list that is used to instantiate a new Book object
        //It is useful because I need to clear authors list in the ReadBook() method to fill it with new data later on
        static List<string> Duplicate(List<string> Authors)
        {
            List<string> temp = new List<string>();
            foreach (var a in Authors)
            {
                temp.Add(a);
            }
            return temp;
        }
        
        
        //FAILED ALTERNATIVE APPROACHES
        /*
         public static string GetBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }
         
         public List<Book> ReadBooks(string input)
        {
            string book1 = GetBetween(input, "Book:", "\n\n");
            Book book = new Book();
            book.SetAuthor(GetBetween(book1, "Author:", "Title"));
            book.SetTitle(GetBetween(book1, "Title:", "Publisher:"));
            book.SetPublisher(GetBetween(book1, "Publisher:", "Published:"));
            book.SetPublicationYear(2015);
            Books.Add(book);
            return Books;
        }*/
        
        //Method that converts a string input into a Book data structure
        /*public List<Book> ReadBooks(string input)
        {
            Book NewBook = new Book();
            string[] words = input.Split(':');

            if (words[0].Equals("Book"))
            {
                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];
                    switch (words[i])
                    {
                        case "Author": // statement sequence
                            NewBook.SetAuthor(words[i + 1]);
                            i++;
                            break;
                        case "Title": // statement sequence
                            NewBook.SetTitle(words[i + 1]);
                            i++;
                            break;
                        case "Publisher": // statement sequence
                            NewBook.SetPublisher(words[i + 1]);
                            i++;
                            break;
                        case "Published": // statement sequence
                            NewBook.SetPublicationYear(Int32.Parse(words[i + 1]));
                            i++;
                            break;
                    }
                }
                Books.Add(NewBook);
            } 
            return Books;
        }*/
        
    }
}