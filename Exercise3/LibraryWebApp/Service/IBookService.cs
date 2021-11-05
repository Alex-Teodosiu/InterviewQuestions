using System.Collections;
using System.Collections.Generic;
using LibraryWebApp.Model;

namespace LibraryWebApp.Service
{
    public interface IBookService
    {
        IList<Book> GetBooks();
        void AddBook(Book _book);
    }
}