using System;
using System.Collections.Generic;
using System.Linq;

namespace Question2
{
    public class Book
    {
        List<string> Authors;
        String Title;
        String Publisher;
        int PublicationYear;

        public Book(List<string> authors, string title, string publisher, int publicationYear)
        {
            Authors = authors;
            Title = title;
            Publisher = publisher;
            PublicationYear = publicationYear;
        }
        
        public string GetTitle()
        {
            return Title;
        }
        
        public string GetPublisher()
        {
            return Publisher;
        }
        
        public int GetPublicationYear()
        {
            return PublicationYear;
        }
        
        public List<string> GetAuthors()
        {
            return Authors;
        }

        public bool ContainsAuthor(string author)
        {
            foreach (var a in Authors)
            {
                if (a.Contains(author))
                    return true;
            }
            return false;
        }

        public string ToString()
        {
            string authors = "";
            foreach (var a in Authors)
            {
                authors += a + " ";
            }
            return authors +"-----"+ Title + "-----" + Publisher + "-----" + PublicationYear;
        }
    }
}